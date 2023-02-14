using BL.DTO;

namespace BL.Interfaces
{
    /// <summary>
    ///     Factory
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        ///     Get sevice based on server request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IServices? GetService(ServiceRequest request);
        /// <summary>
        ///     Execute a request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IServiceResponse> ExecuteRequest(ServiceRequest request);
    }
}
