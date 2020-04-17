using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    public class GroupServiceTests
    {
        [Test]
        public void GroupService_GetAllGroups_ReturnsAllGroups()
        {
            //arrange
            var sampleGroups = new[]
            {
                new Group { Id = 1, Name = "Tall People" },
                new Group { Id = 2, Name = "Short People" }
            };
            var mockContext = new Mock<IApplicationDbContext>();
            var mockContextFactory = new Mock<IApplicationDbContextFactory>();
            mockContextFactory.Setup(m => m.Create(It.IsAny<QueryTrackingBehavior>()))
                .Returns(mockContext.Object);
            var mockGroupRepo = new Mock<IRepository<Group>>();
            mockGroupRepo.Setup(m => m.FetchAll(It.IsAny<IApplicationDbContext>()))
                .Returns(sampleGroups.AsQueryable());
            var groupService = new GroupService(mockContextFactory.Object, mockGroupRepo.Object);

            //act
            var results = groupService.GetAllGroups();

            //assert
            CollectionAssert.AreEquivalent(sampleGroups, results);
        }
    }
}