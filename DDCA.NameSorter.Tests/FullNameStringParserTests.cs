using System;
using System.Linq;
using DDCA.NameSorter.Parser;
using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class FullNameStringParserTests
    {
        [TestCase("Janet Parsons", "Parsons", new[] {"Janet"}, TestName = "First and last name")]
        [TestCase("Adonis Julius Archer", "Archer", new[] {"Adonis", "Julius"}, TestName = "Two given names")]
        [TestCase("Hunter Uriah Mathew Clarke", "Clarke", new[] {"Hunter", "Uriah", "Mathew"}, TestName = "Three given names")]
        public void SuccessfulParse(string source, string expectedLastName, string[] expectedGivenNames)
        {
            var parser = new FullNameStringParser();
            
            var expected = new FullName(expectedLastName, expectedGivenNames);
            var parsed = parser.Parse(source);

            Assert.IsNotNull(parsed);
            Assert.AreEqual(expected.LastName, parsed.LastName);
            Assert.IsTrue(parsed.GivenNames.SequenceEqual(expected.GivenNames));
        }

        [TestCase("", "Full name cannot be empty or whitespace", TestName = "Empty string")]
        [TestCase(" ", "Full name cannot be empty or whitespace", TestName = "Whitespace-only string")]
        [TestCase("Janet", "Not enough parts to construct full name", TestName = "Single name")]
        [TestCase("Janet Julius Nathan Tristan Parsons", "Too many given names", TestName = "More than three given names")]
        [TestCase(" Janet Parsons", "Spaces not allowed at beginning of full name", TestName = "Starting with a space")]
        [TestCase("Janet Parsons ", "Spaces not allowed at end of full name", TestName = "Ending with a space")]
        [TestCase("Janet  Parsons", "Must not have extra spaces between parts", TestName = "More than one space between parts")]
        public void UnsuccessfulParse(string source, string exceptionMessage)
        {
            var parser = new FullNameStringParser();
            var exception = Assert.Throws<ArgumentException>(() => parser.Parse(source));
            Assert.AreEqual(exceptionMessage, exception.Message);
        }

    }
}