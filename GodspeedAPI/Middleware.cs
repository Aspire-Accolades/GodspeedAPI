using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Context.SecureGateContext;
using Godspeed.Infrastructure.Repositories;

namespace GodspeedAPI
{
  public static class Middleware
  {
    public static void Extend(this IServiceCollection services)
    {
      services.AddScoped<AspireContextOptions>();
      services.AddScoped<SecureGateContextOptions>();
      services.AddDbContext<SecureGateContext>();
      services.AddDbContext<AspireWebContext>();
      services.AddScoped<StoreRepository>();
      services.AddScoped<EntityApplicationSettingsRepository>();
      services.AddScoped<BackgroundRepository>();
      services.AddScoped<NavItemsReporsitory>();
      services.AddScoped<FormRepository>();
    }
  }
}
