using System.Collections.Generic;
using JetBrains.Annotations;
using PersonSearch.Domain;

namespace PersonSearch.Service.Contracts
{
    public interface IPersonService
    {
        [NotNull]
        IReadOnlyCollection<Person> GetFilteredListOfPeople(string filterText);
        bool AddNew(string name, int groupId);
    }
}