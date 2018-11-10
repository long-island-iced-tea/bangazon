using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class CustomerStorage
    {
        DatabaseInterface _db;

        public CustomerStorage(DatabaseInterface db)
        {
            _db = db;
        }
    }
}
