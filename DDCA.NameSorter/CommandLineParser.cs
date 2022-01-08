using System;
using System.Data;

namespace DDCA.NameSorter
{
    /// <summary>
    /// Super simple imperative command line parser
    /// </summary>
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
        /// <exception cref="ArgumentOutOfRangeException">count is below zero</exception>
        /// <exception cref="ConstraintException">assertion failed: too many parameters</exception>
        public void AssertMaximumParameterCount(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Maximum count must be at least 0");
            if (_args.Length > count) throw new ConstraintException($"Too many parameters, expecting {count}");
        }

        /// <summary>
        /// Reads the value of the parameter at the specified index. If it does not exist, an ArgumentError will be
        /// thrown.
        /// </summary>
        /// <param name="idx">The index of the parameter</param>
        /// <param name="label">A name to show in error messages</param>
        /// <returns>The value of the parameter</returns>
        /// <exception cref="ArgumentOutOfRangeException">idx is below zero</exception>
        /// <exception cref="IndexOutOfRangeException">user error: not enough arguments</exception>
        public string ReadParameter(int idx, string label)
        {
            if (idx < 0) throw new ArgumentOutOfRangeException(nameof(idx), "Index must be at least 0");

            if (idx >= _args.Length)
            {
                var s = idx == 0 ? "" : "s";
                throw new IndexOutOfRangeException(
                    $"Missing parameter '{label}', expecting at least {idx + 1} parameter{s}");
            }

            return _args[idx];
        }
    }
}