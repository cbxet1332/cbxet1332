using System;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace PersonSearch.Data
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity: class
    {
        private readonly IApplicationDbContextFactory _contextFactory;

        public Repository(IApplicationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<TEntity> FetchAll(IApplicationDbContext context = null)
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

        public IQueryable<TEntity> FetchAll<TProperty>(IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null)
        {
            if (context != null)
            {
                return DoFetchAll(context, includeNavigationProperty);
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return DoFetchAll(newContext, includeNavigationProperty)
                    .AsNoTracking();
            }
        }

        public IQueryable<TEntity> Fetch<TProperty>(Expression<Func<TEntity, bool>> queryExpression, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null)
        {
            if (context != null)
            {
                return DoFetchAll(context, includeNavigationProperty)
                    .Where(queryExpression);
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return DoFetchAll(newContext, includeNavigationProperty)
                    .Where(queryExpression)
                    .AsNoTracking();
            }
        }

        public IQueryable<TEntity> SkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context = null, Expression<Func<TEntity,TProperty>> includeNavigationProperty = null)
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

        public TEntity FindByIndex(int rowIndex, IApplicationDbContext context = null)
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

        public TEntity FindById(int id, IApplicationDbContext context = null)
        {
            if (context != null)
            {
                return context.Set<TEntity>()
                    .Find(id);
            }
            
            using (var newContext = _contextFactory.Create())
            {
                return newContext.Set<TEntity>()
                    .Find(id);
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

        public bool AddNew(TEntity newEntity, IApplicationDbContext context = null)
        {
            if (context != null)
            {
                context.Add(newEntity);
                return context.SaveChanges() == 1;
            }

            using (var newContext = _contextFactory.Create())
            {
                newContext.Add(newEntity);
                return newContext.SaveChanges() == 1;
            }
        }

        [NotNull]
        private static IQueryable<TEntity> DoSkipTake<TProperty>(int qtyToSkip, int qtyToTake, IApplicationDbContext context, Expression<Func<TEntity,TProperty>> include)
        {
            return context.Set<TEntity>()
                .WithInclude(include)
                .Skip(qtyToSkip)
                .Take(qtyToTake);
        }

        [NotNull]
        private static IQueryable<TEntity> DoFetchAll<TProperty>(IApplicationDbContext context, Expression<Func<TEntity,TProperty>> include)
        {
            return context.Set<TEntity>()
                .WithInclude(include);
        }
    }
}