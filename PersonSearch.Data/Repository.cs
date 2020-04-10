using System;
using System.Linq;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Expression = Castle.DynamicProxy.Generators.Emitters.SimpleAST.Expression;

namespace PersonSearch.Data
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity: class
    {
        private readonly IApplicationDbContextFactory _contextFactory;

        public Repository(IApplicationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual IQueryable<TEntity> FetchAll(IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>();
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .AsNoTracking();
            }
        }

        public virtual IQueryable<TEntity> Fetch(Func<TEntity, bool> predicate, IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>()
                    .Where(e => predicate(e));
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .Where(e => predicate(e))
                    .AsNoTracking();
            }
        }

        public virtual IQueryable<TEntity> SkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null)
        {
            if (context != null)
            {
                return DoSkipTake(qtyToSkip, qtyToTake, context, includeNavigationProperty);
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return DoSkipTake(qtyToSkip, qtyToTake, newContext, includeNavigationProperty)
                    .AsNoTracking();
            }
        }

        public virtual TEntity FindByIndex(int rowIndex, IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>()
                    .Skip(rowIndex)
                    .First();
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .Skip(rowIndex)
                    .AsNoTracking()
                    .First();
            }
        }

        public virtual TEntity FindById(int id, IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>()
                    .Find(new[] {id});
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .Find(new[] { id });
            }
        }

        public int Count(IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>().Count();
            }

            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .Count();
            }
        }

        private static IQueryable<TEntity> DoSkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context, Expression<Func<TEntity,TProperty>> include)
        {
            return context.Set<TEntity>()
                .WithInclude(include)
                .Skip(qtyToSkip)
                .Take(qtyToTake);
        }
    }

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> WithInclude<TEntity, TProperty>(this IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> include) where TEntity: class
        {
            return include == null ? 
                query : 
                query.Include(include);
        }
    }
}