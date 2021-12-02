using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Provider
    {
        public DataTable GetAllProviders(ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_GetAllProviders", CommandType.StoredProcedure, ref error);
        }

        public DataTable SearchProvider(string paramName, object paramValue, ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_SearchProvider", CommandType.StoredProcedure,
                   ref error, new SqlParameter(paramName, paramValue));
        }

        public string UpdateInformationProvider(int id, string name, string address, string phoneNumber, bool providing)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateProvider", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("address", address),
                new SqlParameter("phoneNumber", phoneNumber),
                new SqlParameter("state", providing));
            if (error != null)
                return "Update failed!\n" + error;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        }

        public string InsertProvider(string name, string address, string phoneNumber)
        {
            string error = null, message = null;
            bool inserted = BLL.dal.ExecuteNonQuery("sp_InsertProvider", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("name", name),
                new SqlParameter("address", address),
                new SqlParameter("phoneNumber", phoneNumber));
            if (error != null)
                return "Update failed!\n" + error;
            if (!inserted)
                return "No data is updated!";
            return "Update successful!";
        }

        public string DeleteProvider(int pid)
        {
            string error = null, message = null;
            bool deleted = BLL.dal.ExecuteNonQuery("sp_DeleteProvider", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("pid", pid));
            if (error != null)
                return "Delete failed!\n" + error;
            return "Delete successful!";
        }
    }
}
