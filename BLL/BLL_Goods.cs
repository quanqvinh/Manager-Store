using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class BLL_Goods
    {
        public DataTable GetGoodsTable(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetAllGoodsWithProfit", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable GetAllGoods(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetAllGoods", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable GetStokingGoodTable(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetStockingGoods", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable GetSoldOutGoodTable(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetSoldOutGoods", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable GetStopSellingGoodTable(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetStopSellingGoods", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable GetComingSoonGoodTable(ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_GetComingSoonGoods", CommandType.StoredProcedure, ref error);
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable SearchGoods(int id, string state, ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_SearchGoods", CommandType.StoredProcedure, ref error,
                new SqlParameter("id", id), new SqlParameter("state", state));
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public DataTable SearchGoods(string name, string state, ref string error)
        {
            DataTable temp = BLL.dal.ExecuteQueryData("sp_SearchGoods", CommandType.StoredProcedure, ref error,
                new SqlParameter("name", name), new SqlParameter("state", state));
            if (temp == null)
                return null;
            DataTable dt = temp.Clone();
            dt.Columns["Image"].DataType = typeof(bool);
            foreach (DataRow row in temp.Rows)
                dt.ImportRow(row);
            return dt;
        }

        public string UpdateInformationGoods(int id, string name, string unit, double price, bool state, string url)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateGoods", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("unit", unit),
                new SqlParameter("price", price),
                new SqlParameter("state", state),
                new SqlParameter("photo", url),
                new SqlParameter("forceUpdatePhoto", true));
            if (error != null)
                return "Update failed!\n" + error;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        } 

        public string DeleteGoods(int id)
        {
            string error = null, message = null;
            bool deleted = BLL.dal.ExecuteNonQuery("sp_UpdateGoods", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id),
                new SqlParameter("state", false));
            if (error != null)
                return "Delete failed!\n" + error;
            if (!deleted)
                return "No data is deleted";
            return "Delete successful!";
        }

        public string InsertGoods(string name, string unit, double price, string url)
        {
            string error = null, message = null;
            bool inserted = BLL.dal.ExecuteNonQuery("sp_InsertGoods", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("name", name),
                new SqlParameter("unit", unit),
                new SqlParameter("price", price),
                new SqlParameter("photo", url));
            if (error != null)
                return "Insert failed!\n" + error;
            if (!inserted)
                return "Data is not inserted!";
            return "Insert successful!\nPlease insert the contract of it to be showed!";
        }

        public DataTable GetGoodsStillSelling(ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_GetAllGoodsStillSelling", CommandType.StoredProcedure, ref error);
        }
    }
}
