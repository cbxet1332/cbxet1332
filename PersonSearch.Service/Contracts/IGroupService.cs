using System.Collections.Generic;
using JetBrains.Annotations;
using PersonSearch.Domain;

namespace PersonSearch.Service.Contracts
{
    public interface IGroupService
    {
        [NotNull]
        IReadOnlyCollection<Group> GetAllGroups();
    }
}