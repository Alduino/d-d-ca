using System.Collections.Generic;
using System.IO;
using DDCA.NameSorter.Loader;

namespace DDCA.NameSorter
{
    public class FullNameFileReader
    {
        private readonly IFullNameLoader<string> _loader;

        public FullNameFileReader(IFullNameLoader<string> loader)
        {
            _loader = loader;
        }

        /// <summary>
        /// Reads full names from a file, where they are each on individual lines
        /// </summary>
        /// <param name="path">The path to the file to read</param>
        /// <returns>An enumerator of the full names</returns>
        public IEnumerable<IFullName> ReadFromFileLines(string path)
        {
            var lines = File.ReadLines(path);
            return _loader.LoadFromLines(lines);
        }
    }
}