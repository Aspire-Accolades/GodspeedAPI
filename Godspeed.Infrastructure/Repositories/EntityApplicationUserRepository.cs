using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class EntityApplicationUserRepository : GenericRepository<EntityApplicationUser, AspireWebContext>
  {
        public EntityApplicationUserRepository(AspireWebContext ctx) : base(ctx)
        {
        }
    }
}
