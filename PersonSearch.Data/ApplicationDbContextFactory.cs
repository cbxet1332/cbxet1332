using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PersonSearch.Data
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationDbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IApplicationDbContext Create(QueryTrackingBehavior trackChanges = QueryTrackingBehavior.TrackAll)
        {
            var context = _serviceProvider.GetService<ApplicationDbContext>();
            context.ChangeTracker.QueryTrackingBehavior = trackChanges;
            return context;
        }
    }
}