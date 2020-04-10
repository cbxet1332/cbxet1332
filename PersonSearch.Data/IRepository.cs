using System;
using System.Linq;
using System.Linq.Expressions;

namespace PersonSearch.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FetchAll(IApplicationDbContext context = null);
        IQueryable<TEntity> Fetch(Func<TEntity,bool> predicate, IApplicationDbContext context = null);
        IQueryable<TEntity> SkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null);
        TEntity FindByIndex(int rowIndex, IApplicationDbContext context = null);
        TEntity FindById(int id, IApplicationDbContext context = null);
        int Count(IApplicationDbContext context = null);
    }
}