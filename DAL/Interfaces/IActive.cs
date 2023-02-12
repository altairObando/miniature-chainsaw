namespace DAL.Interfaces
{
    /// <summary>
    ///     Interface for activable entities
    /// </summary>
    internal interface IActive
    {
        /// <summary>
        ///     Is active
        /// </summary>
        bool Active { get; }
    }
}
