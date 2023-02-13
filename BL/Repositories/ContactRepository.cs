using DAL.Contacts;
using System.Data;

namespace BL.Repositories
{
    /// <summary>
    ///     Contact repository
    /// </summary>
    public class ContactRepository : BaseRepository<Contact>
    {
        /// <summary>
        ///     Constructor default
        /// </summary>
        /// <param name="context"> Entity context</param>
        /// <param name="con"> SQL Connection for dapper queries</param>
        public ContactRepository(DAL.Context context, IDbConnection con): base(context, con) { }
    }
}
