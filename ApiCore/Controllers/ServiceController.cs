using BL.DTO;
using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceFactory serviceFactory;
        private readonly ILogger<ServiceRequest> _logger;

        public ServiceController(ILogger<ServiceRequest> logger, IServiceFactory factory)
        {
            _logger = logger;
            serviceFactory = factory;
            _logger.BeginScope($"");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            _logger.Log(LogLevel.Information, message: $"Connected");
            return Ok("ONLY POST METHODS");
        }
        [HttpPost]
        public async Task<IServiceResponse> Execute([FromBody] ServiceRequest request)
        {
            try
            {
                //_logger.Log(LogLevel.Information, message: Newtonsoft.Json.JsonConvert.SerializeObject(request));
                var result = await serviceFactory.ExecuteRequest(request);
                _logger.Log(LogLevel.Information, message: Newtonsoft.Json.JsonConvert.SerializeObject(new { 
                    result.Input,
                    Output = new { 
                        result.Output.Status,
                        result.Output.StatusDescription,
                        result.Output.Results.Count
                    }  
                }));
                return result;
            }
            catch (Exception ex)
            {
                var error = new ServiceResponse()
                {
                    Input = request,
                    Output = new OutputResponse()
                    {
                        Status = "Failure",
                        StatusDescription = ex.Message
                    }
                };
                _logger.LogError(Newtonsoft.Json.JsonConvert.SerializeObject(error));
                return error;
            }
        }
    }
}