using Godspeed.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Godspeed.Infrastructure.Repositories.Base
{
  public class GenericRepository<T, TContext> : IDisposable, IGenericCRUD<T>
         where T : class
        where TContext : DbContext

  {
    TContext _ctx;
    public GenericRepository(TContext ctx)
    {
      _ctx = ctx;
    }

    public T Create(T entity)
    {
      try
      {
        _ctx.Entry(entity).State = EntityState.Added;
        _ctx.SaveChanges();
      }
      catch (DbEntityValidationException ex)
      {
        throw (Exception)ex.EntityValidationErrors;
      }
      return entity;
    }

    public IEnumerable<T> Create(IEnumerable<T> entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(Expression<Func<T, bool>> criteria)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      _ctx.Dispose();
    }

    public IQueryable<T> ReadAll()
    {
      IQueryable<T> query = _ctx.Set<T>();
      return query;
    }

    public IQueryable<T> ReadWhere(Expression<Func<T, bool>> criteria)
    {
      IQueryable<T> query = _ctx.Set<T>().Where(criteria);
      return query;
    }

    public void Update(T entity)
    {
      try
      {
        _ctx.Entry(entity).State = EntityState.Modified;
        _ctx.SaveChanges();
      }
      catch (DbEntityValidationException ex)
      {
        throw (Exception)ex.EntityValidationErrors;
      }

    }

    public void Update(IEnumerable<T> entity)
    {
      throw new NotImplementedException();
    }
  }
}