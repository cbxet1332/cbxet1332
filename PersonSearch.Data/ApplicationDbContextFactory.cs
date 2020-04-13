using System;
using System.Threading.Tasks;
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
            // TODO: on rare occasions, despite being configured as transient, container gives a disposed object.
            // TODO: when .GetService<ApplicationDbContext>() is called.
            // TODO: this has only happened when the test page is displayed and the app is being shutdown. 
            // TODO: until I can get to the bottom of this issue, I have implemented a retry mechanism below. 

            bool isError;
            var retryCount = 0;
            ApplicationDbContext context = null;
            do
            {
                try
                {
                    isError = false;
                    context = _serviceProvider.GetService<ApplicationDbContext>();
                    context.ChangeTracker.QueryTrackingBehavior = trackChanges;
                }
                catch
                {
                    isError = true;
                    Task.Delay(250).GetAwaiter().GetResult();
                    retryCount++;
                }
            } while (isError && retryCount < 10);

            if (isError)
            {
                throw new ObjectDisposedException(nameof(context), "Disposed object from _serviceProvider.GetService<ApplicationDbContext>()");
            }

            return context;
        }
    }
}
