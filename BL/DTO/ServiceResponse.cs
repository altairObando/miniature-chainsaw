using BL.Interfaces;

namespace BL.DTO
{
    /// <summary>
    ///  Service response
    /// </summary>
    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponse()
        {
            Input = new ServiceRequest();
            Output = new OutputResponse();
        }        
        /// <summary>
        ///     From request
        /// </summary>
        public IServiceRequest Input { get; set; }
        /// <summary>
        ///     Results from request
        /// </summary>
        public OutputResponse Output { get; set; }
    }
}
