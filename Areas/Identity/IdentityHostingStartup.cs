using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pbshop_web.Areas.Identity.Data;

[assembly: HostingStartup(typeof(pbshop_web.Areas.Identity.IdentityHostingStartup))]
namespace pbshop_web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<pbshop_webIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("pbshop_webIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<pbshop_webIdentityDbContext>();
            });
        }
    }
}