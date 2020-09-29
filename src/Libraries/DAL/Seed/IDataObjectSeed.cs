namespace DAL.Seed
{
    /// <summary>
    /// Interface to define classes that return a simple Entity to be used like seed for demonstration and testing purposes
    /// </summary>
    public interface IDataObjectSeed<TEntity>
    {
        /// <summary>
        /// Returns a entity object to be used like seed
        /// </summary>
        /// <returns></returns>
        TEntity GetSeedObject();
    }
}
