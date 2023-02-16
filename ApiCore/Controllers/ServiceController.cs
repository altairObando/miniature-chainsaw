using BL.DTO;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceFactory serviceFactory;
        private readonly ILogger<BL.DTO.ServiceRequest> _logger;

        public ServiceController(ILogger<BL.DTO.ServiceRequest> logger, IServiceFactory factory)
        {
            _logger = logger;
            serviceFactory = factory;
            _logger.BeginScope($"");
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.Log(LogLevel.Information, message: $"Connected");
            return Ok("ONLY POST METHODS");
        }
        [HttpPost]
        public async Task<IServiceResponse> Execute([FromBody]BL.DTO.ServiceRequest request)
        {
            try
            {
                return await serviceFactory.ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Input = request,
                    Output = new OutputResponse() 
                    {
                        Status = "Failure",
                        StatusDescription = ex.Message
                    }
                };
            }
        }
    }
}