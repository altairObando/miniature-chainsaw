namespace DAL.Interfaces
{
    /// <summary>
    ///     Interface for default catalogs
    /// </summary>
    internal interface ICatalog
    {
        /// <summary>
        ///     Enitity Id
        /// </summary>
        int Id { get; }
        /// <summary>
        ///     Entity code
        /// </summary>
        string Code { get; }
        /// <summary>
        ///     Entity Name
        /// </summary>
        string Name { get; }
        /// <summary>
        ///     Entity status
        /// </summary>
        bool Active { get; }
    }
}
