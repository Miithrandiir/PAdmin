using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PAdmin.Business;
using PAdmin.DbRepository;
using PAdmin.DbRepository.Context;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding EntityFramework
builder.Services.AddDbContextFactory<PAdminContext>(dbContextOptions => dbContextOptions
    .UseMySql(configuration.GetConnectionString("url"), new MySqlServerVersion(new Version(8, 0, 29))));

//Add authentification
var symKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWT:secret"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(symKey),
        ValidateIssuerSigningKey = false,
        ValidateAudience = false
    };
});

//Dependancy Injection
RegisterServices.AddServiceToScoped(builder.Services);
RegisterRepository.AddRepositoryToScoped(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        x.AllowAnyOrigin();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();