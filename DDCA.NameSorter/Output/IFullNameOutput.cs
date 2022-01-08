using System.Collections.Generic;

namespace DDCA.NameSorter.Output
{
    /// <summary>
    /// Provides a method to output a list of full names somewhere
    /// </summary>
    public interface IFullNameOutput
    {
        /// <summary>
        /// Writes the names to this output
        /// </summary>
        void WriteToOutput(IEnumerable<IFullName> names);
    }
}