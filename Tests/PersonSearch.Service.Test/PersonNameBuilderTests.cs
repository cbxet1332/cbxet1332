using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PersonSearch.Service.Services;

namespace PersonSearch.Service.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonNameBuilderTests
    {
        [TestCase("Roscoe Melton", "Roscoe", "Melton", TestName = "Build_001")]
        [TestCase("Frederick Alowishus Bloggs", "Frederick Alowishus", "Bloggs", TestName = "Build_002")]
        [TestCase("Charles William Arthur George Windsor", "Charles William Arthur George", "Windsor", TestName = "Build_003")]
        [TestCase("A.J. Thacker", "A J", "Thacker", TestName = "Build_004")]
        [TestCase("Simon M. Edwards", "Simon M", "Edwards", TestName = "Build_005")]
        [TestCase("Madonna", "Madonna", "", TestName = "Build_006")]
        public void PersonNameBuilder_BuildsPersonNameAsExpected(string name, string expectedForenames, string expectedSurname)
        {
            //arrange
            //act
            var personName = new PersonNameBuilder().Build(name);

            //assert
            Assert.AreEqual(expectedForenames, personName.Forenames);
            Assert.AreEqual(expectedSurname, personName.Surname);
        }
    }
}
