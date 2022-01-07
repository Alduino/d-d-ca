using System.ComponentModel.DataAnnotations;

namespace DDCA.NameSorter
{
    public interface IFullName
    {
        string LastName { get; }

        string[] GivenNames { get; }
    }
}