using System;
using LearnBlazor.Server.Areas.Identity.Data;
using LearnBlazor.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LearnBlazor.Server.Areas.Identity.IdentityHostingStartup))]
namespace LearnBlazor.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LearnBlazorServerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LearnBlazorServerContextConnection")));

                services.AddDefaultIdentity<LearnBlazorServerUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LearnBlazorServerContext>();
            });
        }
    }
}