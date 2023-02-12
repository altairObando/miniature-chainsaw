using BL.DTO;
using BL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace BL.Services
{
    public class ServiceFactory: IServiceFactory, IDisposable
    {
        #region fields and constructor
        private readonly DAL.Context context;
        private readonly IDbConnection connection;
        public ServiceFactory(IConfiguration config) 
        {
            var conString = config.GetConnectionString("CoreContext") ?? "";
            context = new DAL.Context(conString);
            connection = new SqlConnection(conString);
        }
        #endregion
        ///<inheritdoc/>
        public IService? GetService(ServiceRequest request)
        {
            IService? service = request.Command switch
            {
                "Contacts" => new ContactosService(request, context, connection),
                _ => null,
            };
            return service;
        }

        ///<inheritdoc/>
        public IServiceResponse ExecuteRequest(ServiceRequest request)
        {
            var service = GetService(request);
            if(service == null) 
                throw new NullReferenceException(nameof(request.Command));
            service.Execute();
            return service.Response;
        }
        // To detect redundant calls
        private bool _disposedValue;
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                    connection.Dispose();
                }
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true); 
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
