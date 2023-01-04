using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class EntityApplicationSettingsRepository : GenericRepository<StoreSettings, AspireWebContext>
  {
        public EntityApplicationSettingsRepository(AspireWebContext ctx) : base(ctx)
        {
        }
    }
}
