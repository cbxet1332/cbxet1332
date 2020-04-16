using PersonSearch.Service.Models;

namespace PersonSearch.Service.Contracts
{
    public interface IPersonNameBuilder
    {
        PersonName Build(string personName);
    }
}