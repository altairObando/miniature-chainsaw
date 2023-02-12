using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceFactory serviceFactory;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger, IServiceFactory factory)
        {
            _logger = logger;
            serviceFactory = factory;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ONLY POST METHODS ");
        }
        [HttpPost]
        public IServiceResponse Execute([FromBody]BL.DTO.ServiceRequest request) 
            => serviceFactory.ExecuteRequest(request);
    }
}