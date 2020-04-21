using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PersonSearch.Data;
using PersonSearch.Domain;
using PersonSearch.Service.Services;

namespace PersonSearch.Service.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonServiceTests
    {
        [TestCase(null, TestName="GetFilteredListOfPeople_001")]
        [TestCase("",   TestName="GetFilteredListOfPeople_002")]
        public void PersonService_GetFilteredListOfPeopleWithNoFilter_ReturnsFullList(string filter)
        {
            //arrange
            var sampleGroup = new Group { Id = 1, Name = "Test People", CreatedUtc = DateTime.UtcNow };
            var samplePeople = new[]
            {
                new Person { Id = 1, Forenames = "Roscoe", Surname="Melton", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 2, Forenames = "Elvis", Surname="Presley", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 3, Forenames = "Chesney", Surname="Hawks", Group = sampleGroup, CreatedUtc = DateTime.UtcNow }
            };

            var mockContext = new Mock<IApplicationDbContext>();
            var mockContextFactory = new Mock<IApplicationDbContextFactory>();
            mockContextFactory.Setup(m => m.Create(It.IsAny<QueryTrackingBehavior>())).Returns(mockContext.Object);
            var mockPersonRepo = new Mock<IRepository<Person>>();
            mockPersonRepo.Setup(m => m.FetchAll(It.IsAny<IApplicationDbContext>(), person => person.Group)).Returns(samplePeople.AsQueryable());
            mockPersonRepo.Setup(m => m.Fetch(It.IsAny<Expression<Func<Person,bool>>>(), It.IsAny<IApplicationDbContext>(), person => person.Group)).Returns(samplePeople.AsQueryable());
            var mockGroupRepo = new Mock<IRepository<Group>>();
            var personNameBuilder = new PersonNameBuilder();
            var personFilterBuilder = new PersonFilterBuilder();
            var personService = new PersonService(mockContextFactory.Object, mockPersonRepo.Object, mockGroupRepo.Object, personNameBuilder, personFilterBuilder);

            //act
            var results = personService.GetFilteredListOfPeople(filter);

            //assert
            CollectionAssert.AreEquivalent(samplePeople, results);
        }

        [TestCase("roscoe",   "1",   TestName="GetFilteredListOfPeople_003")]
        [TestCase("melton",   "1",   TestName="GetFilteredListOfPeople_004")]
        [TestCase("ros",      "1,5", TestName="GetFilteredListOfPeople_005")]
        [TestCase("aron",     "2,4", TestName="GetFilteredListOfPeople_006")]
        [TestCase("ha",       "3,4", TestName="GetFilteredListOfPeople_007")]
        [TestCase("roscoe m", "1",   TestName="GetFilteredListOfPeople_008")]
        public void PersonService_GetFilteredListOfPeopleWithFilter_ReturnsMatchingPeople(string filter, string expectedIdList)
        {
            //arrange
            var sampleGroup = new Group { Id = 1, Name = "Test People", CreatedUtc = DateTime.UtcNow };
            var samplePeople = new[]
            {
                new Person { Id = 1, Forenames = "Roscoe", Surname="Melton", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 2, Forenames = "Elvis Aaron", Surname="Presley", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 3, Forenames = "Chesney", Surname="Hawks", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 4, Forenames = "Sasha", Surname="Baron-Cohen", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 5, Forenames = "Ross", Surname="Kemp", Group = sampleGroup, CreatedUtc = DateTime.UtcNow }
            };

            var mockContext = new Mock<IApplicationDbContext>();
            var mockContextFactory = new Mock<IApplicationDbContextFactory>();
            mockContextFactory.Setup(m => m.Create(It.IsAny<QueryTrackingBehavior>())).Returns(mockContext.Object);
            var mockPersonRepo = new Mock<IRepository<Person>>();
            mockPersonRepo.Setup(m => m.FetchAll(It.IsAny<IApplicationDbContext>(), person => person.Group)).Returns(samplePeople.AsQueryable());
            mockPersonRepo
                .Setup(m => m.Fetch(
                    It.IsAny<Expression<Func<Person,bool>>>(), 
                    It.IsAny<IApplicationDbContext>(), 
                    person => person.Group))
                .Returns<Expression<Func<Person,bool>>, IApplicationDbContext, Expression<Func<Person,Group>>>
                    ((filterExpression, _, __) => samplePeople.AsQueryable().Where(filterExpression));
            var mockGroupRepo = new Mock<IRepository<Group>>();
            var personNameBuilder = new PersonNameBuilder();
            var personFilterBuilder = new PersonFilterBuilder();
            var personService = new PersonService(mockContextFactory.Object, mockPersonRepo.Object, mockGroupRepo.Object, personNameBuilder, personFilterBuilder);

            //act
            var results = personService.GetFilteredListOfPeople(filter);

            //assert
            var expectedIds = expectedIdList.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var actualIds = results.Select(p => p.Id);
            CollectionAssert.AreEquivalent(expectedIds, actualIds);
        }

        [Test]
        public void PersonService_AddNewWithValidDetails_ReturnsTrueAndAddsToRepo()
        {
            //arrange
            var sampleGroup = new Group { Id = 1, Name = "Test People", CreatedUtc = DateTime.UtcNow };
            var samplePeople = new List<Person>(new[] 
            {
                new Person { Id = 1, Forenames = "Roscoe", Surname="Melton", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 2, Forenames = "Elvis Aaron", Surname="Presley", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 3, Forenames = "Chesney", Surname="Hawks", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 4, Forenames = "Sasha", Surname="Baron-Cohen", Group = sampleGroup, CreatedUtc = DateTime.UtcNow },
                new Person { Id = 5, Forenames = "Ross", Surname="Kemp", Group = sampleGroup, CreatedUtc = DateTime.UtcNow }
            });

            var mockContext = new Mock<IApplicationDbContext>();
            var mockContextFactory = new Mock<IApplicationDbContextFactory>();
            mockContextFactory.Setup(m => m.Create(It.IsAny<QueryTrackingBehavior>())).Returns(mockContext.Object);
            var mockPersonRepo = new Mock<IRepository<Person>>();
            mockPersonRepo
                .Setup(m => m.AddNew(It.IsAny<Person>(), It.IsAny<IApplicationDbContext>()))
                .Returns<Person, IApplicationDbContext>((person, _) =>
                {
                    samplePeople.Add(person);
                    return true;
                });
            var mockGroupRepo = new Mock<IRepository<Group>>();
            mockGroupRepo
                .Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<IApplicationDbContext>()))
                .Returns(sampleGroup);
            var personNameBuilder = new PersonNameBuilder();
            var personFilterBuilder = new PersonFilterBuilder();
            var personService = new PersonService(mockContextFactory.Object, mockPersonRepo.Object, mockGroupRepo.Object, personNameBuilder, personFilterBuilder);

            //act
            var result = personService.AddNew("Ainsley Harriot", 1);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(samplePeople.Any(p => p.Surname == "Harriot"));
            mockPersonRepo.Verify(r => r.AddNew(It.IsAny<Person>(), It.IsAny<IApplicationDbContext>()), Times.Once);
            mockGroupRepo.Verify(r => r.FindById(It.IsAny<int>(), It.IsAny<IApplicationDbContext>()), Times.Once);
        }

        [TestCase(null,          1, TestName = "AddNew_001")]
        [TestCase("",            1, TestName = "AddNew_002")]
        [TestCase("Fred Bloggs", 0, TestName = "AddNew_003")]
        public void PersonService_AddNewWithInvalidName_ReturnsFalseAndDoesNotAddToRepo(string name, int groupId)
        {
            //arrange
            var mockContext = new Mock<IApplicationDbContext>();
            var mockContextFactory = new Mock<IApplicationDbContextFactory>();
            mockContextFactory.Setup(m => m.Create(It.IsAny<QueryTrackingBehavior>())).Returns(mockContext.Object);
            var mockPersonRepo = new Mock<IRepository<Person>>();
            var mockGroupRepo = new Mock<IRepository<Group>>();
            var personNameBuilder = new PersonNameBuilder();
            var personFilterBuilder = new PersonFilterBuilder();
            var personService = new PersonService(mockContextFactory.Object, mockPersonRepo.Object, mockGroupRepo.Object, personNameBuilder, personFilterBuilder);

            //act
            var result = personService.AddNew(name, groupId);

            //assert
            Assert.IsFalse(result);
            mockPersonRepo.Verify(r => r.AddNew(It.IsAny<Person>(), It.IsAny<IApplicationDbContext>()), Times.Never);
            mockGroupRepo.Verify(r => r.FindById(It.IsAny<int>(), It.IsAny<IApplicationDbContext>()), Times.Never);
        }
    }

}