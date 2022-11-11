using Godspeed.Domain.Models.UI;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class NavItemsReporsitory : GenericRepository<NavLinks, AspireWebContext>
  {
        public NavItemsReporsitory(AspireWebContext ctx) : base(ctx)
        {
        }
    }
}
