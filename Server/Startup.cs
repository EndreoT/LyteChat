using LyteChat.Server.Auth;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Hubs;
using LyteChat.Server.Persistence.Context;
using LyteChat.Server.Persistence.Repositories;
using LyteChat.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LyteChat.Server
{
    public class Startup
    {
        private readonly SymmetricSecurityKey SecurityKey;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string? jwtSecret = Configuration["JWT:Secret"];
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new ArgumentException("JWT signing key is not configured");
            }
            SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStrId = "DefaultConnection";
#if DEBUG
            connectionStrId = "DEV";
#endif
            string? connectionStr = Configuration.GetConnectionString(connectionStrId);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddMvc();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default User settings.
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(options =>
            {
                // Identity made Cookie authentication the default.
                // However, we want JWT Bearer Auth to be the default.
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;  // Set to true for prod
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = SecurityKey
                    };

                    // We have to hook the OnMessageReceived event in order to
                    // allow the JWT authentication handler to read the access
                    // token from the query string when a WebSocket or
                    // Server-Sent Events request comes in.

                    // Sending the access token in the query string is required due to
                    // a limitation in Browser APIs. We restrict it to only calls to the
                    // SignalR hub in this code.
                    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
                    // for more information about security considerations when using
                    // the query string to transmit the access token.
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/chathub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                       {
                           return Task.CompletedTask;
                       },
                        OnForbidden = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSignalR();

            // Authorization services
            services
               .AddAuthorization(options =>
               {
                   options.AddPolicy(AuthPolicy.UserCanCreateChatMessage, policy =>
                   {
                       //For chat hub auth
                       policy.Requirements.Add(new UserCanCreateChatMessageRequirement());
                   });
               });
            //For chat hub auth
            services.AddScoped<IAuthorizationHandler, UserCanCreateChatMessageRequirementHandler>();
            //For REST API auth
            services.AddScoped<IAuthorizationHandler, UserIsChatGroupMemberAuthHandler>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            // Repositories
            services.AddScoped<IChatGroupRepository, ChatGroupRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatGroupUserRepository, ChatGroupUserRepository>();
            // App services
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<IChatGroupService, ChatGroupService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatGroupUserService, ChatGroupUserService>();
            // DB services
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // TODO add swagger back
            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Lyte Chat API",
            //        Description = "Real time chat application API",
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Tristan Endreo",
            //            Email = "endreotm@gmail.com",
            //            Url = new Uri("https://www.linkedin.com/in/tristan-endreo/"),
            //        }
            //    });
            //    // Set the comments path for the Swagger JSON and UI.
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            // TODO add swagger back
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LyteChat API V1");
            //});

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}