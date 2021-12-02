using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL
    {
        public static DataAccess dal = new DataAccess("ADMIN");
    }
}
