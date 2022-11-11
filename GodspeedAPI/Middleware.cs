
using Godspeed.Infrastructure.Context;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Helpers;
using Godspeed.Infrastructure.Repositories;

namespace GodspeedAPI
{
  public static class Middleware
  {
    public static void Extend(this IServiceCollection services)
    {
      services.AddScoped<AspireContextOptions>();
      services.AddDbContext<AspireWebContext>();
      services.AddScoped<EntityRepository>();
      services.AddScoped<EntityApplicationRepository>();
      services.AddScoped<EntityApplicationSettingsRepository>();
      services.AddScoped<BackgroundRepository>();
      services.AddScoped<NavItemsReporsitory>();
      services.AddScoped<FormRepository>();
      services.AddScoped<ApplicationHelper>();
    }
  }
}
