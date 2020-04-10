using System;
using Microsoft.EntityFrameworkCore;

namespace PersonSearch.Data
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}