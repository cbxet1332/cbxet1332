using PersonSearch.Service.Models;

namespace PersonSearch.Service.Contracts
{
    public interface IPersonFilterBuilder
    {
        PersonFilter Build(string filterText);
    }
}