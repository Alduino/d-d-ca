using System.Collections.Generic;

namespace DDCA.NameSorter.Loader
{
    /// <summary>
    /// Provides methods to load full names
    /// </summary>
    /// <typeparam name="T">The source type to load from</typeparam>
    public interface IFullNameLoader<in T>
    {
        /// <summary>
        /// Load names from a list of "lines"
        /// </summary>
        /// <param name="lines">Each line is one serialised name</param>
        /// <returns>A list of loaded full names</returns>
        IEnumerable<IFullName> LoadFromLines(IEnumerable<T> lines);
    }
}