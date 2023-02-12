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
        IService? GetService(ServiceRequest request);
        /// <summary>
        ///     Execute a request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IServiceResponse ExecuteRequest(ServiceRequest request);
    }
}
