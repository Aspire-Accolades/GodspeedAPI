using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class EntityApplicationRepository : GenericRepository<EntityApplication, AspireWebContext>
  {
        public EntityApplicationRepository(AspireWebContext ctx) : base(ctx)
        {

        }
    }
}
