using Aspire.Security;
using Aspire.Security.Secrets;
using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.DatabaseContext;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Interfaces;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", optional: false)
       .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AspireDBContext>(options => options.UseSqlServer(SQLConnectionStringBuilder.GetConnectionString(config)));
builder.Services.AddScoped<EntityRepository>();
builder.Services.AddScoped<EntityApplicationRepository>();
builder.Services.AddScoped<EntityApplicationSettingsRepository>();
builder.Services.AddScoped<EntityApplicationUserRepository>();
builder.Services.AddScoped<NavItemsReporsitory>();
builder.Services.AddScoped<BackgroundRepository>();
builder.Services.AddScoped<ApplicationSettings>();
builder.Services.AddScoped<PasswordRepository>();
builder.Services.AddScoped<PersonRepository>();

builder.Services.AddMvc();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
