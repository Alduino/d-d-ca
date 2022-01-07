using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class FullNameComparerTests
    {
        [TestCase("Parsons", new [] {"_"}, "Lewis", new [] {"_"}, 1, TestName = "Compares different last names")]
        [TestCase("Parsons", new [] {"_"}, "Parsons", new [] {"_"}, 0, TestName = "Compares equal last names")]
        [TestCase("Parsons", new [] {"Adonis"}, "Lewis", new [] {"Janet"}, 1, TestName = "Ignores first name if last names are different")]
        [TestCase("Parsons", new [] {"Adonis"}, "Parsons", new [] {"Janet"}, -1, TestName = "Compares first name if last names are equal")]
        [TestCase("Parsons", new [] {"Adonis"}, "Parsons", new [] {"Adonis"}, 0, TestName = "Compares equal first name if last names are equal and there are no more given names")]
        [TestCase("Parsons", new [] {"Adonis", "Julius"}, "Parsons", new [] {"Adonis", "Uriah"}, -1, TestName = "Compares second given name if first and last names are equal")]
        [TestCase("Parsons", new [] {"Adonis", "Julius"}, "Parsons", new [] {"Adonis"}, -1, TestName = "Fewer given names compares to be greater than more")]
        [TestCase("Parsons", new [] {"Adonis", "Julius"}, "Parsons", new [] {"Adonis", "Julius"}, 0, TestName = "Compares equal names to be equal")]
        [TestCase(null, new string[0], null, new string[0], 0, TestName = "Compares two null names to be equal")]
        [TestCase(null, new string[0], "Parsons", new [] { "Adonis" }, -1, TestName = "A non-null name compares to be greater than a null name")]
        public void Compare(string? xLast, string[] xGiven, string? yLast, string[] yGiven, int expected)
        {
            var xName = xLast == null ? null : new FullName(xLast, xGiven);
            var yName = yLast == null ? null : new FullName(yLast, yGiven);

            var comparer = new FullNameComparer();
            var result = comparer.Compare(xName, yName);
            Assert.AreEqual(expected, result);
        }
    }
}