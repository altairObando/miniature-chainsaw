using BL.DTO;
using BL.Interfaces;
using DAL.Catalogs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace BL.Services
{
    public class ServiceFactory: IServiceFactory, IDisposable
    {
        const string CATALOG = "Catalog";
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
        public IServices? GetService(ServiceRequest request)
        {
            if(string.IsNullOrEmpty(request.Command))
                throw new ArgumentNullException(nameof(request));

            if (request.Command.Contains(CATALOG))
            {
                var serviceName = request.Command.Replace(CATALOG, string.Empty).Trim();
                return serviceName switch
                {
                    ServicesEnum.Cities  => new CityService(request, context, connection, nameof(City)),
                    ServicesEnum.Country => new CountryService(request, context, connection, nameof(Country)),
                    ServicesEnum.Region  => new RegionService(request, context, connection, nameof(Region)),
                    ServicesEnum.State   => new StateService(request, context, connection, nameof(State)),
                    ServicesEnum.MaritalStatus => new StateService(request, context, connection, nameof(MaritalStatus)),
                    _ => null
                };
            }

            return request.Command switch
            {
                ServicesEnum.Contactos => new ContactService(request, context, connection),
                ServicesEnum.Address => new AddressService(request, context, connection),
                _ => null,
            };
        }

        ///<inheritdoc/>
        public async Task<IServiceResponse> ExecuteRequest(ServiceRequest request)
        {
            var service = GetService(request);
            if(service == null) 
                throw new NullReferenceException($"Command : { request.Command } not exists");
            await service.Execute();
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
