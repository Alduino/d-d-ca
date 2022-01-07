using System;
using System.Data;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace DDCA.NameSorter.Tests
{
    [TestFixture]
    public class CommandLineParserTests
    {
        private static readonly Regex ExMessageParam = new(" \\(Parameter '[^']+'\\)$");

        [TestCase(new string[0], 0, TestName = "No parameters allowed and none supplied")]
        [TestCase(new string[0], 1, TestName = "Up to one parameter allowed and none supplied")]
        [TestCase(new[] { "single-param" }, 1, TestName = "Up to one parameter allowed and one supplied")]
        [TestCase(new[] { "single-param" }, 2, TestName = "Up to two parameters allowed and one supplied")]
        [TestCase(new[] { "param-one", "param-two" }, 2, TestName = "Up to two parameters allowed and two supplied")]
        public void AssertMaximumParameterCountSuccessful(string[] args, int maximumCount)
        {
            var parser = new CommandLineParser(args);
            Assert.DoesNotThrow(() => parser.AssertMaximumParameterCount(maximumCount));
        }

        [TestCase(new string[0], -1, "Maximum count must be at least 0", typeof(ArgumentOutOfRangeException), TestName = "Invalid maximum count")]
        [TestCase(new[] { "single-param" }, 0, "Too many parameters, expecting 0", typeof(ConstraintException), TestName = "Any parameters when expecting zero")]
        [TestCase(new[] { "param-one", "param-two", "param-three" }, 2, "Too many parameters, expecting 2", typeof(ConstraintException), TestName = "More parameters than expected")]
        public void AssertMaximumParameterCountUnsuccessful(string[] args, int maximumCount, string expectedMessage, Type exceptionType)
        {
            var parser = new CommandLineParser(args);
            var ex = Assert.Throws(exceptionType, () => parser.AssertMaximumParameterCount(maximumCount));
            Assert.AreEqual(expectedMessage, ExMessageParam.Replace(ex.Message, ""));
        }

        [TestCase(new[] { "single-param" }, 0, "label", "single-param", TestName = "Read the only parameter")]
        [TestCase(new[] { "param-one", "param-two" }, 0, "label", "param-one", TestName = "Read the first parameter")]
        [TestCase(new[] { "param-one", "param-two" }, 1, "label", "param-two", TestName = "Read the last parameter")]
        [TestCase(new[] { "param-one", "param-two", "param-three" }, 1, "label", "param-two", TestName = "Read a middle parameter")]
        public void ReadParameterSuccessful(string[] args, int idx, string label, string expected)
        {
            var parser = new CommandLineParser(args);
            var param = parser.ReadParameter(idx, label);
            Assert.AreEqual(expected, param);
        }

        [TestCase(new string[0], -1, "label", "Index must be at least 0", typeof(ArgumentOutOfRangeException), TestName = "Invalid index")]
        [TestCase(new string[0], 0, "label", "Missing parameter 'label', expecting at least 1 parameter", typeof(IndexOutOfRangeException), TestName = "Read parameter that doesn't exist")]
        [TestCase(new string[0], 1, "label", "Missing parameter 'label', expecting at least 2 parameters", typeof(IndexOutOfRangeException), TestName = "Read a later parameter that doesn't exist")]
        [TestCase(new[] { "single-param" }, 1, "label", "Missing parameter 'label', expecting at least 2 parameters", typeof(IndexOutOfRangeException), TestName = "Read the second parameter when only one exists")]
        public void ReadParameterUnsuccessful(string[] args, int idx, string label, string expectedMessage, Type exceptionType)
        {
            var parser = new CommandLineParser(args);
            var ex = Assert.Throws(exceptionType, () => parser.ReadParameter(idx, label));
            Assert.AreEqual(expectedMessage, ExMessageParam.Replace(ex.Message, ""));
        }
    }
}