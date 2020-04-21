using System;
using Microsoft.EntityFrameworkCore;
using PersonSearch.Service.Contracts;
using PersonSearch.Service.Models;

namespace PersonSearch.Service.Services
{
    public class PersonFilterBuilder : IPersonFilterBuilder
    {
        public PersonFilter Build(string filterText)
        {
            var lowerFilterText = filterText.ToLowerInvariant();
            var filterWords = lowerFilterText.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (filterWords.Length == 1)
            {
                return new PersonFilter
                {
                    MatchWords = filterWords,
                    GetFilter = words =>
                        person =>
                            EF.Functions.Like(person.Forenames, $"%{words[0]}%") ||
                            EF.Functions.Like(person.Surname, $"%{words[0]}%") ||
                            EF.Functions.Like(person.Group.Name, $"%{words[0]}%")
                };
            }


            if (filterWords.Length == 2)
            {
                return new PersonFilter
                {
                    MatchWords = filterWords,
                    GetFilter = words =>
                        person => 
                            (
                                EF.Functions.Like(person.Forenames, $"{words[0]}%") &&
                                EF.Functions.Like(person.Forenames, $"% {words[1]}%")
                            ) ||
                            (
                                EF.Functions.Like(person.Forenames, $"{words[0]}%") &&
                                (
                                    EF.Functions.Like(person.Surname, $"{words[1]}%") ||
                                    EF.Functions.Like(person.Group.Name, $"{words[1]}%")
                                )
                            ) ||
                            (
                                EF.Functions.Like(person.Surname, $"{words[0]}%") &&
                                EF.Functions.Like(person.Group.Name, $"{words[1]}%")
                            )
                };
            }

            if (filterWords.Length == 3)
            {
                return new PersonFilter
                {
                    MatchWords = filterWords,
                    GetFilter = words =>
                        person => 
                            (
                                EF.Functions.Like(person.Forenames, $"{words[0]}%") &&
                                EF.Functions.Like(person.Forenames, $"%{words[1]}%") &&
                                EF.Functions.Like(person.Forenames, $"%{words[2]}%")
                            ) ||
                            (
                                EF.Functions.Like(person.Forenames, $"{words[0]}%") &&
                                EF.Functions.Like(person.Forenames, $"%{words[1]}%") &&
                                (
                                    EF.Functions.Like(person.Surname, $"{words[2]}%") ||
                                    EF.Functions.Like(person.Group.Name, $"{words[2]}%")
                                )
                            ) ||
                            (
                                EF.Functions.Like(person.Forenames, $"{words[0]}%") &&
                                EF.Functions.Like(person.Surname, $"{words[1]}%") &&
                                EF.Functions.Like(person.Group.Name, $"{words[2]}%")
                            )
                };
            }

            return new PersonFilter
            {
                GetFilter = _ => __ => true
            };
        }
    }
}