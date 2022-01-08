using DDCA.NameSorter.Serialiser;
using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class FullNameStandardStringSerialiserTests
    {
        [TestCase("Parsons", new[] { "Janet" }, "Janet Parsons", TestName = "Single given name")]
        [TestCase("Archer", new[] { "Adonis", "Julius" }, "Adonis Julius Archer", TestName = "Two given names")]
        [TestCase("Clarke", new[] { "Hunter", "Uriah", "Mathew" }, "Hunter Uriah Mathew Clarke", TestName = "Three given names")]
        public void Serialise(string lastName, string[] givenNames, string expected)
        {
            var serialiser = new FullNameStandardStringSerialiser();

            var name = new FullName(lastName, givenNames);
            var actual = serialiser.Serialise(name);

            Assert.AreEqual(expected, actual);
        }
    }
}