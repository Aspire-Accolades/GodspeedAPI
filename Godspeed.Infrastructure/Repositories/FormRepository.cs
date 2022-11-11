using Godspeed.Domain.Models.UI;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class FormRepository : GenericRepository<Forms, AspireWebContext>
  {
    public FormRepository(AspireWebContext ctx) : base(ctx)
    {
    }
  }
}
