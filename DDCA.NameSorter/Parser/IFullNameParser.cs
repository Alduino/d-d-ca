namespace DDCA.NameSorter.Parser
{
    /// <summary>
    /// Provides a method to parse IFullNames from some type
    /// </summary>
    /// <typeparam name="T">The source type - could be a string, another name type, etc</typeparam>
    public interface IFullNameParser<in T>
    {
        /// <summary>
        /// Parses the source into a FullName
        /// </summary>
        public IFullName Parse(T source);
    }
}