using Aspire.Security;
using Aspire.Security.Secrets;
using Aspire.Util;
using AspireAPI.Domain.DAL;
using AspireAPI.Domain.DAL.DatabaseContext;
using AspireAPI.Domain.DAL.UI;
using AspireAPI.Infrastructure.Helpers;
using AspireAPI.Infrastructure.Interfaces;
using AspireAPI.Infrastructure.Repositories;
using GodspeedAPI;
using GodspeedAPI.Models;
using HttpTracing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HttpEventListener>();
builder.Services.AddScoped<Logger>();
builder.Services.AddScoped<SQLConnectionManager>();
builder.Services.AddDbContext<AspireDBContext>();
builder.Services.AddScoped<InjectionHelper>();
InjectionHelper.Extend(builder.Services);
builder.Services.AddScoped<ApplicationSettings>();
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
