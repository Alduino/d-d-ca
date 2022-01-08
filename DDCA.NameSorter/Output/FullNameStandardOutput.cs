using System;
using System.Collections.Generic;
using DDCA.NameSorter.Serialiser;

namespace DDCA.NameSorter.Output
{
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