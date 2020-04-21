using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using PersonSearch.Domain;
using PersonSearch.Service.Services;

namespace PersonSearch.Service.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonFilterBuilderTests
    {
        private static readonly IQueryable<Group> SampleGroupData = new[]
        {
            new Group {Id = 1, Name = "Family"},
            new Group {Id = 2, Name = "Colleagues"},
            new Group {Id = 3, Name = "Actors"},
            new Group {Id = 4, Name = "Friends"}
        }.AsQueryable();

        private static readonly IQueryable<Person> SamplePersonData = new[]
        {
            new Person {Id = 1, Forenames = "Simon Marc", Surname = "Edwards", Group = SampleGroupData.First(g => g.Id == 1)},
            new Person {Id = 2, Forenames = "Joan Evelyn", Surname = "Edwards", Group = SampleGroupData.First(g => g.Id == 1)},
            new Person {Id = 3, Forenames = "Jeff", Surname = "Simons", Group = SampleGroupData.First(g => g.Id == 2)},
            new Person {Id = 4, Forenames = "Simon", Surname = "Ward", Group = SampleGroupData.First(g => g.Id == 3)},
            new Person {Id = 5, Forenames = "Toni", Surname = "Piccolo", Group = SampleGroupData.First(g => g.Id == 4)},
            new Person {Id = 6, Forenames = "James William Edward", Surname = "Kemp", Group = SampleGroupData.First(g => g.Id == 4)},
            new Person {Id = 7, Forenames = "Jackie Anne", Surname = "Edwards", Group = SampleGroupData.First(g => g.Id == 4)}
        }.AsQueryable();

        [TestCase("simon", "1,3,4", TestName="BuildWithOneWord_001")]
        [TestCase("j", "2,3,6,7", TestName="BuildWithOneWord_002")]
        [TestCase("to", "4,5", TestName="BuildWithOneWord_003")]
        [TestCase("jeff", "3", TestName="BuildWithOneWord_004")]
        [TestCase("fam", "1,2", TestName="BuildWithOneWord_005")]
        [TestCase("edward", "1,2,6,7", TestName="BuildWithOneWord_006")]
        public void PersonFilterBuilder_BuildWithOneWord_MatchesOnPartOfAnyData(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
        }

        [TestCase("si ed", "1", TestName="BuildWithTwoWords_001")]
        [TestCase("t p", "5", TestName="BuildWithTwoWords_002")]
        [TestCase("j si", "3", TestName="BuildWithTwoWords_003")]
        [TestCase("j k", "6", TestName="BuildWithTwoWords_004")]
        [TestCase("si fam", "1", TestName="BuildWithTwoWords_005")]
        [TestCase("imon ed", "", TestName="BuildWithTwoWords_006")]
        public void PersonFilterBuilder_BuildWithTwoWords_MatchesOnForenamesStartAndSurnameOrGroup(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            if (string.IsNullOrEmpty(expectedIds))
            {
                CollectionAssert.IsEmpty(results);
            }
            else
            {
                CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
            }
        }

        [TestCase("ed fam", "1,2", TestName="BuildWithTwoWords_007")]
        [TestCase("si col", "3", TestName="BuildWithTwoWords_008")]
        public void PersonFilterBuilder_BuildWithTwoWords_MatchesOnSurnameStartAndGroup(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            if (string.IsNullOrEmpty(expectedIds))
            {
                CollectionAssert.IsEmpty(results);
            }
            else
            {
                CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
            }
        }

        [TestCase("si ma", "1", TestName="BuildWithTwoWords_009")]
        [TestCase("j w", "6", TestName="BuildWithTwoWords_010")]
        public void PersonFilterBuilder_BuildWithTwoWords_MatchesOnForenames(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            if (string.IsNullOrEmpty(expectedIds))
            {
                CollectionAssert.IsEmpty(results);
            }
            else
            {
                CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
            }
        }

        [TestCase("si ed fam", "1", TestName="BuildWithThreeWords_001")]
        [TestCase("j s col", "3", TestName="BuildWithThreeWords_002")]
        public void PersonFilterBuilder_BuildWithThreeWords_MatchesOnForenamesSurnameAndGroupName(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            if (string.IsNullOrEmpty(expectedIds))
            {
                CollectionAssert.IsEmpty(results);
            }
            else
            {
                CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
            }
        }

        [TestCase("j w e", "6", TestName="BuildWithThreeWords_003")]
        public void PersonFilterBuilder_BuildWithThreeWords_MatchesOnForenames(string filterText, string expectedIds)
        {
            //arrange
            var personFilterBuilder = new PersonFilterBuilder();
            
            //act
            var results = SamplePersonData.Where(personFilterBuilder.Build(filterText).Filter);

            //assert
            if (string.IsNullOrEmpty(expectedIds))
            {
                CollectionAssert.IsEmpty(results);
            }
            else
            {
                CollectionAssert.AreEquivalent(expectedIds.Split(new [] {','}).Select(int.Parse), results.Select(p => p.Id));
            }
        }
    }
}