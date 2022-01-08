using System;
using System.Collections.Generic;
using DDCA.NameSorter.Serialiser;

namespace DDCA.NameSorter.Output
{
    /// <summary>
    /// Writes the names to standard output, where each name is on its own line
    /// </summary>
    public class FullNameStandardOutput : IFullNameOutput
    {
        private readonly IFullNameSerialiser<string> _serialiser;

        public FullNameStandardOutput(IFullNameSerialiser<string> serialiser)
        {
            _serialiser = serialiser;
        }

        public void WriteToOutput(IEnumerable<IFullName> names)
        {
            foreach (var name in names)
            {
                var serialised = _serialiser.Serialise(name);
                Console.WriteLine(serialised);
            }
        }
    }
}