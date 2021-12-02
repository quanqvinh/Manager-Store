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
    public class BLL_Contract
    {
        public DataTable GetAllGoodsReceipt(ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_GetAllContracts", CommandType.StoredProcedure, ref error);
        }

        public DataTable SearchInContract(string paramName, object paramValue, ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_SearchContracts", CommandType.StoredProcedure, 
                ref error, new SqlParameter(paramName, paramValue));
        }

        public DataTable DetailGoodsInContract(int cid, ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_DetailGoodsInContract", CommandType.StoredProcedure,
                   ref error, new SqlParameter("cid", cid));
        }

        public string UpdateInfomationContract(int cid, string gname, string unit, double gprice, string gphoto,
            string pname, string paddress, string pphonenumber, int eid, string cdate, int cquantity, double cprice)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateContract", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("cid", cid),
                new SqlParameter("gname", gname),
                new SqlParameter("unit", unit),
                new SqlParameter("gprice", gprice),
                new SqlParameter("gphoto", gphoto),
                new SqlParameter("pname", pname),
                new SqlParameter("paddress", paddress),
                new SqlParameter("pphonenumber", pphonenumber),
                new SqlParameter("eid", eid),
                new SqlParameter("cdate", cdate),
                new SqlParameter("cquantity", cquantity),
                new SqlParameter("cprice", cprice));
            if (error != null)
                return "Update failed!\n" + error;
            if (!string.IsNullOrEmpty(message.Trim()))
                return "Update failed!\n" + message;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        }

        public string DeleteContract(int cid)
        {
            string error = null, message = null;
            bool deleted = BLL.dal.ExecuteNonQuery("sp_DeleteContract", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("cid", cid));
            if (error != null)
                return "Delete failed!\n" + error;
            return "Delete successful!";
        }

        public string DeleteGoodsInContract(int cid, string gname)
        {
            string error = null, message = null;
            bool deleted = BLL.dal.ExecuteNonQuery("sp_DeleteGoodsInContract", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("cid", cid),
                new SqlParameter("gname", gname));
            if (error != null)
                return "Delete failed!\n" + error;
            return "Delete successful!";

        }

        public int GetNewContractID()
        {
            string error = null;
            return (int)BLL.dal.ExecuteScalar("select dbo.ft_CreateContractId()", CommandType.Text, ref error);
        }

        public string InsertContract(int cid, string gname, string unit, double gprice, string gphoto, string pname, 
            int eid, string date, int cquantity, double cprice)
        {
            string error = null, message = null;
            bool inserted = BLL.dal.ExecuteNonQuery("sp_InsertContract", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("cid", cid),
                new SqlParameter("gname", gname),
                new SqlParameter("unit", unit),
                new SqlParameter("gprice", gprice),
                new SqlParameter("gphoto", gphoto),
                new SqlParameter("pname", pname),
                new SqlParameter("eid", eid),
                new SqlParameter("date", date),
                new SqlParameter("cquantity", cquantity),
                new SqlParameter("cprice", cprice));
            if (error != null)
                return "Insert failed!\n" + error;
            if (!string.IsNullOrEmpty(message.Trim()))
                return "Insert failed!\n" + message;
            if (!inserted)
                return "No data is inserted!";
            return "Insert successful!";
        }

        public string DeleteProvider(string pname)
        {
            string error = null, message = null;
            bool deleted = BLL.dal.ExecuteNonQuery("sp_DeleteProvider", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("pname", pname));
            if (error != null)
                return "Delete failed!\n" + error;
            return "Delete successful!";
        }
    }
}
