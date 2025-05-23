using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewEvent.DAL;
using NewEvent.Models;

namespace NewEvent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }

                ).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }

                );


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllerRoute(
                "admin",
                "{area:exists}/{Controller=home}/{Action=index}/{id?}"

                );

            app.MapControllerRoute(
                "default",
                "{Controller=home}/{Action=index}/{id?}"

                );

            app.Run();
        }
    }
}
