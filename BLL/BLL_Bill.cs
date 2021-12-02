using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bill
    {

        public DataTable GetAllBills(ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_GetAllBills", CommandType.StoredProcedure, ref error);
        }

        public DataTable SearchBills(string paramName, object paramValue, ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_SearchBill", CommandType.StoredProcedure, ref error, new SqlParameter(paramName, paramValue));
        }

        public string UpdateBill(int bid, int eid, string time)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateBill", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("bid", bid),
                new SqlParameter("eid", eid),
                new SqlParameter("time", time));
            if (error != null)
                return "Update failed!\n" + error;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        }

        public string UpdateBill(int bid, int gid, int quantity)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateBill", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("bid", bid),
                new SqlParameter("gid", gid),
                new SqlParameter("quantity", quantity));
            if (error != null)
                return "Update failed!\n" + error;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        }

        public string DeleteBill(int bid)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_DeleteBill", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("bid", bid));
            if (error != null)
                return "Delete failed!\n" + error;
            if (!updated)
                return "No data is deleted!";
            return "Delete successful!";
        }

        public string DeleteBill(int bid, int gid)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_DeleteGoodsInBill", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("bid", bid),
                new SqlParameter("gid", gid));
            if (error != null)
                return "Delete failed!\n" + error;
            if (!updated)
                return "No data is deleted!";
            return "Delete successful!";
        }

        public int GetNewBillID()
        {
            string error = null;
            return (int)BLL.dal.ExecuteScalar("select dbo.ft_CreateBillId()", CommandType.Text, ref error);
        }

        public string InsertBill(int bid, string gname, int eid, int quantity)
        {
            string error = null, message = null;
            bool inserted = BLL.dal.ExecuteNonQuery("sp_InsertBill", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("bid", bid),
                new SqlParameter("gname", gname),
                new SqlParameter("eid", eid),
                new SqlParameter("quantity", quantity));
            if (error != null)
                return "Insert failed!\n" + error;
            if (!inserted)
                return "No data is inserted!";
            return "Insert successful!";
        }
    }
}
