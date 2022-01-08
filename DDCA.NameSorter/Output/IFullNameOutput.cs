using System.Collections.Generic;

namespace DDCA.NameSorter.Output
{
    public interface IFullNameOutput
    {
        void WriteToOutput(IEnumerable<IFullName> names);
    }
}