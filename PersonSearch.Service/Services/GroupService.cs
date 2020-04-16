using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonSearch.Data;
using PersonSearch.Domain;
using PersonSearch.Service.Contracts;

namespace PersonSearch.Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IApplicationDbContextFactory _contextFactory;
        private readonly IRepository<Group> _groupRepo;

        public GroupService(
            IApplicationDbContextFactory contextFactory, 
            IRepository<Group> groupRepo)
        {
            _contextFactory = contextFactory;
            _groupRepo = groupRepo;
        }

        public IReadOnlyCollection<Group> GetAllGroups()
        {
            using (var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                return _groupRepo
                    .FetchAll(context)
                    .ToArray();
            }

        }
    }
}