using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Domain.Interfaces
{
  public interface IGenericCRUD<Model>
  where Model : class
  {
    Model Create(Model entity);
    IEnumerable<Model> Create(IEnumerable<Model> entity);
    IQueryable<Model> ReadWhere(Expression<Func<Model, bool>> criteria);
    IQueryable<Model> ReadAll();
    void Update(Model entity);
    void Update(IEnumerable<Model> entity);
    void Delete(Model entity);
    void Delete(Expression<Func<Model, bool>> criteria);
    void Dispose();
  }
}
