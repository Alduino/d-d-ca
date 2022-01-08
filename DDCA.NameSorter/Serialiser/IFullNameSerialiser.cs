namespace DDCA.NameSorter.Serialiser
{
    /// <summary>
    /// Provides a method to convert full names into a different format
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    public interface IFullNameSerialiser<out T>
    {
        /// <summary>
        /// Serialises a full name into a `T`
        /// </summary>
        T Serialise(IFullName fullName);
    }
}