namespace DDCA.NameSorter
{
    /// <summary>
    /// Stores some number of given names and a last name
    /// </summary>
    public interface IFullName
    {
        string LastName { get; }

        string[] GivenNames { get; }
    }
}