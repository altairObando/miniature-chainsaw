using Azure;
using BL.DTO;
using BL.Interfaces;
using BL.Repositories;
using DAL.Contacts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BL.Services
{
    /// <summary>
    ///     Contract implementation
    /// </summary>
    public class ContactosService : IService
    {
        #region Private properties, Constructor and implementations
        private readonly DAL.Context _cntx;
        private readonly ContactosRepository _repo;
        private readonly IDbConnection _conn;
        public IServiceRequest Request { get; set; }
        public ServiceResponse Response {get; set;}
        
        public ContactosService(IServiceRequest request, DAL.Context context, IDbConnection connection) 
        {
            _cntx    = context;
            _conn    = connection;
            _repo    = new ContactosRepository(context, _conn);
            Request  = request;
            Response = new ServiceResponse() { Input = request, Output = new OutputResponse() };
        }
        #endregion
        /// <inheritdoc/>
        public async Task Get()
        {
            var data = await _repo.GetAll(Request.Fields ?? string.Empty, Request.Filter ?? string.Empty);
            AddResult(data);
            return;
        }
        /// <inheritdoc/>
        public async Task Add()
        {
            if(string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Contact));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Add(entity);

            Response.Output.Results.Add(newEntity);
        }
        /// <inheritdoc/>
        public async Task Update()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Contact));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Update(entity);
            
            Response.Output.StatusDescription = "Updated";
            Response.Output.Results.Add(newEntity);
        }
        /// <inheritdoc/>
        public async Task Delete()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Contact));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Delete(entity);

            Response.Output.StatusDescription = "Removed";
            Response.Output.Results.Add(newEntity);
        }
        /// <inheritdoc/>
        public async Task Execute()
        {
            try
            {
                switch (Request.Operation)
                {
                    case ServiceOperations.GET: await Get(); break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Output.Status = "Error";
                Response.Output.StatusDescription = ex.Message;

            }
        }
        /// <inheritdoc/>
        public void AddResult(IEnumerable<Contact> data)
        {            
            foreach (var contact in data)
                Response.Output.Results.Add(contact);
        }        
    }
}
