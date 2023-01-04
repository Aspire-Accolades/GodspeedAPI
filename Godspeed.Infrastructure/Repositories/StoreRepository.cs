using Godspeed.Domain.Models.Manage;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Context.SecureGateContext;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class StoreRepository : GenericRepository<Store, SecureGateContext>
  {
        public StoreRepository(SecureGateContext ctx) : base(ctx)
        {

        }
    }
}
