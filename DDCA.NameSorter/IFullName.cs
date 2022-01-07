using System.ComponentModel.DataAnnotations;

namespace DDCA.NameSorter
{
    public interface IFullName
    {
        string LastName { get; }
        
        [MinLength(1)]
        [MaxLength(3)]
        string[] GivenNames { get; }
    }
}