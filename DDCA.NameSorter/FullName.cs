using System;
using System.Linq;

namespace DDCA.NameSorter
{
    public class FullName : IFullName
    {
        /// <summary>
        /// Parses a FullName where each part of the name is separated by spaces. A FullName has a last name, and
        /// between one and three given names.
        /// </summary>
        /// <param name="source">The source text to parse the full name. Should be trimmed and have a single space
        /// between parts.</param>
        /// <returns>A full name parsed from the string</returns>
        public static FullName Parse(string source)
        {
            throw new NotImplementedException();
        }

        public FullName(string lastName, string firstName) : this(lastName, new[] { firstName })
        {
        }

        public FullName(string lastName, string[] givenNames)
        {
            LastName = lastName;
            GivenNames = givenNames;
        }

        public string LastName { get; }
        public string[] GivenNames { get; }
    }
}