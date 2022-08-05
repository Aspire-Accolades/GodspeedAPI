using Aspire.Security.Secrets;
using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.DatabaseContext;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Interfaces;
using AspireAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AspireDBContext>(options => options.UseSqlServer(Keys.ConnectionString));
builder.Services.AddScoped<IGenericCRUD<Entity>, EntityRepository>();
builder.Services.AddScoped<IGenericCRUD<EntityApplication>, EntityApplicationRepository>();
builder.Services.AddScoped<IGenericCRUD<EntityApplicationSettings>, EntityApplicationSettingsRepository>();
builder.Services.AddScoped<IGenericCRUD<NavLinks>, NavItemsReporsitory>();
builder.Services.AddScoped<IGenericCRUD<Background>, BackgroundRepository>();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(x => x
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
