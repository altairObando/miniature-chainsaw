using BL.DTO;
using BL.Interfaces;
using BL.Repositories;
using DAL;
using DAL.Catalogs;
using System.Data;

namespace BL.Services
{
    internal class RegionService : IServices
    {
        private readonly DAL.Context _cntx;
        private readonly CatalogRepository<Region> _repo;
        private readonly IDbConnection _conn;
        public IServiceRequest Request { get; set; }
        public RegionService(IServiceRequest request, Context context, IDbConnection connection, string name)
        {

            _conn = connection;
            _cntx = context;
            _repo = new CatalogRepository<Region>(_cntx, _conn, name);
            Request = request;
            Response = new ServiceResponse() { Input = request, Output = new OutputResponse() };

        }
        public ServiceResponse Response { get; set; }

        public async Task Add()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Region));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Add(entity);

            Response.Output.Results.Add(newEntity);
        }

        public async Task Delete()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Region));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Delete(entity);

            Response.Output.StatusDescription = "Removed";
            Response.Output.Results.Add(newEntity);
        }

        public async Task Execute()
        {
            try
            {
                switch (Request.Operation)
                {
                    case ServiceOperations.GET: await Get(); break;
                    case ServiceOperations.ADD: await Add(); break;
                    case ServiceOperations.DELETE: await Delete(); break;
                    case ServiceOperations.UPDATE: await Update(); break;
                    default: throw new ArgumentException(nameof(Request.Operation));
                }
            }
            catch (Exception ex)
            {
                Response.Output.Status = "Error";
                Response.Output.StatusDescription = ex.Message;

            }
        }

        public async Task Get()
        {
            var data = await _repo.GetAll(Request.Fields ?? string.Empty, Request.Filter ?? string.Empty);
            AddResult(data);
            return;
        }

        public async Task Update()
        {
            if (string.IsNullOrEmpty(Request.Entity))
                throw new NullReferenceException(nameof(Region));

            var entity = _repo.GetEntityFromJson(Request.Entity);
            var newEntity = await _repo.Update(entity);

            Response.Output.StatusDescription = "Updated";
            Response.Output.Results.Add(newEntity);
        }
        public void AddResult(IEnumerable<Region> data)
        {
            foreach (var item in data)
                Response.Output.Results.Add(item);
        }
    }
}
