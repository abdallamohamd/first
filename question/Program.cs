using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using question.Models;
using question.repository;

namespace question
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(50);
            });
            builder.Services.AddDbContext<appcontext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddScoped<Ijobrepo,jobrepo>();
            builder.Services.AddScoped<Iapplicationrepo,applicationrepo>();

           builder.Services.AddIdentity<applicant,IdentityRole>().AddEntityFrameworkStores<appcontext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
