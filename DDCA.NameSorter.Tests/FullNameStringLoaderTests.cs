using System.Linq;
using DDCA.NameSorter.Loader;
using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class FullNameStringLoaderTests
    {
        private class ParserMock : IFullNameParser<string>
        {
            public IFullName Parse(string source)
            {
                return new FullName(source, "_");
            }
        }

        [TestCase(TestName = "No names")]
        [TestCase("Parsons", TestName = "Single name")]
        [TestCase("Parsons", "Lewis", "Archer", "Yoder", TestName = "Many names")]
        public void LoadFromLines(params string[] lines)
        {
            var parser = new ParserMock();
            var loader = new FullNameStringLoader(parser);
            var loaded = loader.LoadFromLines(lines);
            var loadedLastNames = loaded.Select(name => name.LastName);
            Assert.IsTrue(lines.SequenceEqual(loadedLastNames));
        }
    }
}