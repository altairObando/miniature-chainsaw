using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    internal class AddressRepository : BaseRepository<DAL.Contacts.Address>
    {
        public AddressRepository(Context context, IDbConnection connection) : base(context, connection)
        {
        }
    }
}
