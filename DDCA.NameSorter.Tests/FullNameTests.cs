using System;
using System.Linq;
using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class FullNameTests
    {
        [Test]
        public void FirstLastNameConstructor()
        {
            var actual = new FullName("Parsons", "Janet");
            var expected = new FullName("Parsons", new[] { "Janet" });
            
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.IsTrue(expected.GivenNames.SequenceEqual(actual.GivenNames));
        }
    }
}