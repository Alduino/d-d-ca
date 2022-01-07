using System;

namespace DDCA.NameSorter
{
    public class CommandLineParser
    {
        private readonly string[] _args;

        /// <summary>
        /// Loads the command line arguments. Parsing will happen lazily.
        /// </summary>
        /// <param name="args">Command line arguments passed into Main method</param>
        public CommandLineParser(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// Throws if the number of command line parameters is greater than count
        /// </summary>
        public void AssertMaximumParameterCount(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the value of the parameter at the specified index. If it does not exist, an ArgumentError will be
        /// thrown.
        /// </summary>
        /// <param name="idx">The index of the parameter</param>
        /// <param name="label">A name to show in error messages</param>
        /// <returns>The value of the parameter</returns>
        public string ReadParameter(int idx, string label)
        {
            throw new NotImplementedException();
        }
    }
}