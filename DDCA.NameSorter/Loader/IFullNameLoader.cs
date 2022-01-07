using System.Collections.Generic;

namespace DDCA.NameSorter
{
    public interface IFullNameLoader<in T>
    {
        IEnumerable<IFullName> LoadFromLines(IEnumerable<T> lines);
    }
}