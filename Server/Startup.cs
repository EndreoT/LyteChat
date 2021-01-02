using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using LyteChat.Server.Hubs;
using LyteChat.Server.Persistence.Context;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Persistence.Repositories;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Services;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Data.Models;

namespace LyteChat.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    // Configure the Authority to the expected value for your authentication provider
            //    // This ensures the token is appropriately validated
            //    options.Authority = /* TODO: Insert Authority URL here */;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = jwtSettings.Issuer,
            //        ValidAudience = jwtSettings.Issuer,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            //        ClockSkew = TimeSpan.Zero
            //    };

            //    // We have to hook the OnMessageReceived event in order to
            //    // allow the JWT authentication handler to read the access
            //    // token from the query string when a WebSocket or 
            //    // Server-Sent Events request comes in.

            //    // Sending the access token in the query string is required due to
            //    // a limitation in Browser APIs. We restrict it to only calls to the
            //    // SignalR hub in this code.
            //    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
            //    // for more information about security considerations when using
            //    // the query string to transmit the access token.
            //    options.Events = new JwtBearerEvents
            //    {
            //        OnMessageReceived = context =>
            //        {
            //            var accessToken = context.Request.Query["access_token"];

            //            // If the request is for our hub...
            //            var path = context.HttpContext.Request.Path;
            //            if (!string.IsNullOrEmpty(accessToken) &&
            //                (path.StartsWithSegments("/chathub")))
            //            {
            //                // Read the token out of the query string
            //                context.Token = accessToken;
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //});

            //services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

            services.AddSignalR();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //ENABLE CORS
            //app.UseCors(x => x
            //   .AllowAnyMethod()
            //   .AllowAnyHeader()
            //   .SetIsOriginAllowed(origin => true) // allow any origin  
            //   .AllowCredentials());               // allow credentials 

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
