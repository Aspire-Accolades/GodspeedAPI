using Godspeed.Domain.Models.Directory;
using Godspeed.Infrastructure.Context.Aspire;
using Godspeed.Infrastructure.Repositories.Base;

namespace Godspeed.Infrastructure.Repositories
{
  public class PersonRepository : GenericRepository<Person, AspireWebContext>
  {
        public PersonRepository(AspireWebContext ctx) : base(ctx)
        {
        }
    }
}
