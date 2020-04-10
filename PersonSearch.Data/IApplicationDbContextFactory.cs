using Microsoft.EntityFrameworkCore;

namespace PersonSearch.Data
{
    public interface IApplicationDbContextFactory
    {
        IApplicationDbContext Create(QueryTrackingBehavior trackChanges = QueryTrackingBehavior.TrackAll);
    }
}