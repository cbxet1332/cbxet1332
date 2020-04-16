using System;
using System.Linq;
using System.Linq.Expressions;

namespace PersonSearch.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FetchAll(IApplicationDbContext context = null);
        IQueryable<TEntity> FetchAll<TProperty>(IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null);
        IQueryable<TEntity> Fetch<TProperty>(Expression<Func<TEntity,bool>> queryExpression, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null);
        IQueryable<TEntity> SkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null);
        TEntity FindByIndex(int rowIndex, IApplicationDbContext context = null);
        TEntity FindById(int id, IApplicationDbContext context = null);
        int Count(IApplicationDbContext context = null);
        void AddNew(TEntity newEntity, IApplicationDbContext context = null);
    }
}