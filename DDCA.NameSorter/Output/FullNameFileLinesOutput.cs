using System.Collections.Generic;
using System.IO;
using System.Linq;
using DDCA.NameSorter.Serialiser;

namespace DDCA.NameSorter.Output
{
    /// <summary>
    /// Writes the names to a file, where each name is on its own line
    /// </summary>
    public class FullNameFileLinesOutput : IFullNameOutput
    {
        private readonly IFullNameSerialiser<string> _serialiser;
        private readonly string _path;

        public FullNameFileLinesOutput(IFullNameSerialiser<string> serialiser, string path)
        {
            _serialiser = serialiser;
            _path = path;
        }

        public void WriteToOutput(IEnumerable<IFullName> names)
        {
            var serialisedNames = names.Select(_serialiser.Serialise);
            File.WriteAllLines(_path, serialisedNames);
        }
    }
}