using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opt =>
        {
            opt.LoginPath = "/auth/login";
            opt.LogoutPath = "/auth/logout";
            opt.AccessDeniedPath = "/auth/denied";
            opt.ExpireTimeSpan = TimeSpan.FromDays(30);
            opt.Cookie.Name = "cse.net.vn";
        });
builder.Services.AddMvc();
builder.Services.AddTransient<SiteProvider>();

var app = builder.Build();
app.UseAuthorization();
app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
app.Run();
