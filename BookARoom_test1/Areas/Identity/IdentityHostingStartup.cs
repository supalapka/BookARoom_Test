using BookARoom_test1.Areas.Identity.Data;
using BookARoom_test1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BookARoom_test1.Areas.Identity.IdentityHostingStartup))]
namespace BookARoom_test1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthContextConnection")));

                services.AddDefaultIdentity<AuthUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireUppercase = false;

                }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthContext>();

                //services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultUI()
                //       .AddDefaultTokenProviders()
                //       .AddEntityFrameworkStores<AuthContext>();
            });
        }
    }
}