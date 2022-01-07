using System;
using System.Collections.Generic;

namespace DDCA.NameSorter
{
    /// <summary>
    /// Compares FullNames first by the last name, then by any given names. If a name has fewer given names than
    /// another, it will compare higher.
    /// </summary>
    public class FullNameComparer : Comparer<IFullName>
    {
        public override int Compare(IFullName? x, IFullName? y)
        {
            throw new NotImplementedException();
        }
    }
}