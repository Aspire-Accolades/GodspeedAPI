using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class EntityRepository : GenericRepository<Entity, AspireWebContext>
  {
    public Entity Current { get; set; }
    public EntityRepository(AspireWebContext ctx) : base(ctx)
    {
      
    }
  }
}
