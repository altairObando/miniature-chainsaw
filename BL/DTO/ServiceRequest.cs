using BL.Interfaces;

namespace BL.DTO
{
    /// <summary>
    ///  Server request.
    /// </summary>
    public class ServiceRequest : IServiceRequest
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? Command { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? Operation { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? Entity { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? Filter { get; set; }
        /// <inheritdoc/>
        public string? Fields { get; set; }
    }
}
