using System.Collections.Generic;
using System.IO;
using System.Linq;
using DDCA.NameSorter.Serialiser;

namespace DDCA.NameSorter.Output
{
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