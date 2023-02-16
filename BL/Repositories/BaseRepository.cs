using BL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;

namespace BL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Constructores de la clase
        private readonly DAL.Context _context;
        private readonly IDbConnection _dbConn;
        /// <summary>
        ///     Constructor class
        /// </summary>
        /// <param name="context"> Core context, CRUD operations</param>
        /// <param name="connection">Dapper connections for queries </param>
        public BaseRepository(DAL.Context context, IDbConnection connection) 
        {
            _context = context;
            _dbConn  = connection;
        }
        private DbSet<TEntity> GetDbSet() => _context.Set<TEntity>();
        #endregion

        /// <inheritdoc/>
        public async Task<TEntity?> GetById(int id) => await GetDbSet().FindAsync(id);
        /// <inheritdoc/>
        public async Task<IEnumerable<TEntity>> GetAll(string fields, string filter, string tableName)
        {
            var query = $" SELECT {(string.IsNullOrEmpty(fields) ? "*" : fields)} " +
                        $" FROM   { tableName } " +
                        $" {(string.IsNullOrEmpty(filter) ? string.Empty : $" WHERE {filter}")}";
            query = query.Trim();
            return await _dbConn.QueryAsync<TEntity>(query);
        }
        /// <inheritdoc/>
        public async Task<TEntity> Add(TEntity entity)
        {
            await GetDbSet().AddAsync(entity);
            await Save();
            return entity;
        }
        /// <inheritdoc/>
        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
            return entity;
        }
        /// <inheritdoc/>
        public async Task<TEntity> Delete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
            await Save();
            return entity;
        }
        /// <inheritdoc/>
        public async Task<TEntity> Delete(int id)
        {
            var entity = GetDbSet().Find(id);
            if (entity == null)
                throw new NullReferenceException("Registro no econtrado");
            GetDbSet().Remove(entity);
            await Save();
            return entity;
        }
        /// <inheritdoc/>
        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
        // Extra Methods
        /// <summary>
        ///     Search entities by lambda function
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate) => (IQueryable<TEntity>)GetDbSet().Where(predicate);
        /// <summary>
        ///     Get entity by entity fields
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TEntity?> FindByKeys(params object[] keyValues) => await GetDbSet().FindAsync(keyValues);
        /// <inheritdoc/>
        public TEntity GetEntityFromJson(string json)
        {
            var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(json ?? "{}");
            if (entity == null)
                throw new NoNullAllowedException("Entity cant be null");
            return entity;
        }

    }
}
