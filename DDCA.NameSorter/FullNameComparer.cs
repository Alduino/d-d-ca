using System;
using System.Collections.Generic;

namespace DDCA.NameSorter
{
    /// <summary>
    /// Compares FullNames first by the last name, then by any given names.
    /// </summary>
    public class FullNameComparer : Comparer<IFullName>
    {
        private readonly StringComparison _comparison;

        public FullNameComparer(StringComparison comparison = StringComparison.CurrentCulture)
        {
            _comparison = comparison;
        }

        public override int Compare(IFullName? x, IFullName? y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var lastNameComparison = string.Compare(x.LastName, y.LastName, _comparison);
            if (lastNameComparison != 0) return lastNameComparison;

            var mostGivenNames = Math.Max(x.GivenNames.Length, y.GivenNames.Length);
            for (var i = 0; i < mostGivenNames; i++)
            {
                if (i >= x.GivenNames.Length) return 1;
                if (i >= y.GivenNames.Length) return -1;

                var xGivenName = x.GivenNames[i];
                var yGivenName = y.GivenNames[i];

                var comparison = string.Compare(xGivenName, yGivenName, _comparison);
                if (comparison != 0) return comparison;
            }

            return 0;
        }
    }
}