using System.Threading.Tasks;

namespace BL.Interfaces
{
    /// <summary>
    ///     Generic repository patter
    /// </summary>
    /// <typeparam name="TEntity"> Entity </typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        ///     Get element by id
        /// </summary>
        /// <param name="id"> PK value </param>
        /// <returns></returns>
        Task<TEntity?> GetById(int id);
        /// <summary>
        ///     Get all entites by sql filters 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll(string fields, string filter, string tableName);
        /// <summary>
        ///     Attach and save new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Add(TEntity entity);
        /// <summary>
        ///     Update and save entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity entity);
        /// <summary>
        ///     Search entity by id then remove
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> Delete(int id);
        /// <summary>
        ///     Remove and save an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Delete(TEntity entity);
        /// <summary>
        ///     Savechanges
        /// </summary>
        /// <returns></returns>
        Task<bool> Save();
        /// <summary>
        ///     Extract entity from json values
        /// </summary>
        /// <param name="json"> entity in json format</param>
        /// <returns></returns>
        TEntity GetEntityFromJson(string json);
    }
}
