using System;
using System.Linq;
using PersonSearch.Service.Contracts;
using PersonSearch.Service.Models;

namespace PersonSearch.Service.Services
{
    public class PersonNameBuilder : IPersonNameBuilder
    {
        public PersonName Build(string personName)
        {
            string forenames;
            var surname = string.Empty;

            var names = personName.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 1)
            {
                forenames = names[0];
            }
            else
            {
                surname = names.Last();
                forenames = string.Join(" ", names.Take(names.Length - 1));
            }

            return new PersonName {Forenames = forenames, Surname = surname};
        }
    }
}