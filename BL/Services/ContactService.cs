using Azure;
using BL.DTO;
using BL.DTO.Contacts;
using BL.Interfaces;
using BL.Repositories;
using DAL.Contacts;
using Esprima.Ast;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BL.Services
{
    /// <summary>
    ///     Contract implementation
    /// </summary>
    public class ContactService : IServices
    {
        #region Private properties, Constructor and implementations
        private readonly DAL.Context _cntx;
        private readonly ContactRepository _repo;
        private readonly IDbConnection _conn;
        public IServiceRequest Request { get; set; }
        public ServiceResponse Response {get; set;}
        
        public ContactService(IServiceRequest request, DAL.Context context, IDbConnection connection) 
        {
            _cntx    = context;
            _conn    = connection;
            _repo    = new ContactRepository(context, _conn);
            Request  = request;
            Response = new ServiceResponse() { Input = request, Output = new OutputResponse() };
        }
        #endregion
        /// <inheritdoc/>
        public async Task Get()
        {
            var data = await _repo.GetAll(Request.Fields ?? string.Empty, Request.Filter ?? string.Empty, nameof(Contact));
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
            AddResult(newEntity);
        }
        /// <inheritdoc/>
        public async Task Update()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Contact));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Update(entity);
            
            Response.Output.StatusDescription = "Updated";
            AddResult(newEntity);
        }
        /// <inheritdoc/>
        public async Task Delete()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Contact));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Delete(entity);
            
            Response.Output.StatusDescription = "Removed";
            AddResult(newEntity);
        }
        /// <inheritdoc/>
        public async Task Execute()
        {
            try
            {
                switch (Request.Operation)
                {
                    case ServiceOperations.GET:    await Get(); break;
                    case ServiceOperations.ADD:    await Add(); break;
                    case ServiceOperations.DELETE: await Delete(); break;
                    case ServiceOperations.UPDATE: await Update(); break;
                    default: throw new ArgumentException(nameof(Request.Operation));
                }
            }
            catch (Exception ex)
            {
                Response.Output.Status = "Error";
                Response.Output.StatusDescription = ex?.InnerException?.Message ?? ex?.Message ?? string.Empty;

            }
        }
        /// <inheritdoc/>
        public void AddResult(IEnumerable<Contact> data)
        {            
            foreach (var contact in data)
                Response.Output.Results.Add(Mapper.ObjectMapper.Mapper.Map<Contact, ContactDto>(contact));
        }        
        public void AddResult(Contact data) 
            => Response.Output.Results.Add(Mapper.ObjectMapper.Mapper.Map<Contact, ContactDto>(data));
    }
}
