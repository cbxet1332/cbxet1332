using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PersonSearch.Data
{
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