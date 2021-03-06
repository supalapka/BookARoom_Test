using BookARoom_test1.Areas.Identity.Data;
using BookARoom_test1.Data;
using DataLibrary.BusinessLogic;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.DataAccess;
using DataLibrary.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookARoom_test1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SqlDataAccess.connectionString = Configuration.GetConnectionString("connectionString");
            MyDbContext.connectionString = Configuration.GetConnectionString("connectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<IHotel, HotelProcessor>();//dapper
            services.AddSingleton<IHotel, HotelRepository>(); //entity

            services.AddSingleton<IRoom, RoomProcessor>();//dapper
            services.AddSingleton<IRoom, RoomRepository>();//entity

            services.AddDbContext<MyDbContext>();

        }   






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
