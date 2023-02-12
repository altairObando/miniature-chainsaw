using System.Data;

namespace BL.Repositories
{
    //TODO: Add documentation and test
    public class CatalogRepository<ICatalog> where ICatalog : class
    {
        private readonly BaseRepository<ICatalog> repository;
        public CatalogRepository(DAL.Context context, IDbConnection con)
        {
            repository = new BaseRepository<ICatalog>(context, con);
        }
        public async Task Add(ICatalog entity) 
            => await repository.Add(entity);

        public async Task Delete(int id) 
            => await repository.Delete(id);

        public async Task Delete(ICatalog entity) 
            => await repository.Delete(entity);

        public async Task<IEnumerable<ICatalog>> GetAllAsync(string fields, string filter) 
            => await repository.GetAll(fields, filter);

        public async Task<ICatalog?> GetByIdAsync(int id)
            => await repository.GetById(id);

        public async Task Save() 
            => await repository.Save();

        public async Task Update(ICatalog entity) 
            => await repository.Update(entity);

    }
}
