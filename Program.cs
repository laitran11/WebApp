using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
byte[] key = Encoding.ASCII.GetBytes("aksdfjlaskfjaskofjadf");

builder.Services.AddAuthentication(p =>
{
    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p =>
{
    p.RequireHttpsMetadata = false;
    p.SaveToken = true;
    p.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = true,
    };
});



builder.Services.AddTransient<SiteProvider>();
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.MapControllers();
app.Run();
