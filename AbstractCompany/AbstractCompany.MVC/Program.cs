using AbstractCompany.Identity;
using AbstractCompany.Identity.Models;
using AbstractCompany.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddTransient<EmailService>();

services.AddIdentity<User, IdentityRole>()
   .AddEntityFrameworkStores<DatabaseContext>()
   .AddDefaultTokenProviders();

services.Configure<IdentityOptions>(opt =>
{
    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";

    opt.Lockout.MaxFailedAccessAttempts = 10;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
});

services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "AbstractCompany";
    opt.Cookie.HttpOnly = true;

    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";

    opt.SlidingExpiration = true;
});

services.AddControllersWithViews();

services.AddDbContext<DatabaseContext>(s => s.UseSqlite(configuration.GetConnectionString("Identity")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();