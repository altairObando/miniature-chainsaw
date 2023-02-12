using BL.Services;
using Jint;
using Jint.Runtime;
using Newtonsoft.Json;
using System.Dynamic;

namespace BL.Javascript
{
    /// <summary>
    ///     Jint Engine for formulas
    /// </summary>
    public class CustomEngine
    {
        #region Fields and constructor
        private readonly Engine engine;
        private readonly ServiceFactory _serviceFactory;
        public CustomEngine(ServiceFactory factory)
        {
            engine = new Engine(cfg => cfg.AllowClr());
            engine.SetValue("doCmd", GetValueFromService);
            _serviceFactory = factory;
        }
        #endregion
        /// <summary>
        ///     Execute js code
        /// </summary>
        /// <param name="customJs"></param>
        /// <returns></returns>
        public string Eval(string customJs)
        {
            dynamic response = new ExpandoObject();
            try
            {
                engine
                .SetValue("res", response)
                .Execute(@"
                    const custom =()=>{
                        " + customJs + @"
                    }
                    res.result = custom();");
                return JsonConvert.SerializeObject(response.result);
            }
            catch (JintException ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        ///     Performs service request
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="NullReferenceException"></exception>
        private void GetValueFromService(DTO.ServiceRequest request)
        {
            var service = _serviceFactory.GetService(request);
            if (service == null)
                throw new NullReferenceException("Service not found");
            service.Execute();
            var jsonResponse = JsonConvert.SerializeObject(service.Response);
            engine.SetValue(request.Command ?? string.Empty, jsonResponse);
            engine.Execute($" {request.Command} = JSON.parse({request.Command}); ");
        }
    }
}
