using Aspire.Security;
using Aspire.Util;
using AspireAPI.Domain.DAL.DatabaseContext;
using AspireAPI.Infrastructure.Helpers;
using GodspeedAPI.Models;
using HttpTracing;

namespace GodspeedAPI
{
  public static class Middleware
  {
    public static void Extend(this IServiceCollection services)
    {
      services.AddScoped<HttpEventListener>();
      services.AddSingleton<Logger>();
      services.AddSingleton<BaseHandler>();
      services.AddSingleton<SQLConnectionManager>();
      services.AddDbContext<AspireDBContext>();
      services.AddScoped<ApplicationSettings>();

    }
  }
}
