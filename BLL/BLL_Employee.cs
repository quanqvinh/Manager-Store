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
    public class BLL_Employee
    {
        private DataTable CustomTable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
                if (row["Role"].ToString().ToLower().Contains("admin"))
                {
                    row["Working Days"] = DBNull.Value;
                    row["Day's Wage"] = DBNull.Value;
                    row["Month Salary"] = DBNull.Value;
                }
            return dt;
        }

        public DataTable GetAllEmployee(ref string error)
        {
            DataTable dt = BLL.dal.ExecuteQueryData("sp_GetAllemployees", CommandType.StoredProcedure, ref error);
            if (dt == null)
                return null;
            return CustomTable(dt);
        }

        public DataTable GetStockManagers(ref string error)
        {
            DataTable dt = BLL.dal.ExecuteQueryData("sp_GetStockManagers", CommandType.StoredProcedure, ref error);
            if (dt == null)
                return null;
            return CustomTable(dt);
        }

        public DataTable GetStaffs(ref string error)
        {
            DataTable dt = BLL.dal.ExecuteQueryData("sp_GetStaffs", CommandType.StoredProcedure, ref error);
            if (dt == null)
                return null;
            return CustomTable(dt);
        }

        public DataTable GetRetiredEmployee(ref string error)
        {
            DataTable dt = BLL.dal.ExecuteQueryData("sp_GetAllRetiredEmployee", CommandType.StoredProcedure, ref error);
            if (dt == null)
                return null;
            return CustomTable(dt);
        }

        public DataTable SearchEmployee(string searchBy, string text, string role, ref string error)
        {
            searchBy = searchBy.ToLower();
            if (role != null)
                role = role.ToUpper();
            if (searchBy.Contains("phone"))
                searchBy = "phoneNumber";
            DataTable dt = BLL.dal.ExecuteQueryData("sp_SearchEmployee", CommandType.StoredProcedure, ref error,
                new SqlParameter("role", role),
                new SqlParameter(searchBy, text));
            if (dt == null)
                return null;
            return CustomTable(dt);
        }

        public string UpdateInformationEmployee(int id, string name, string phoneNumber, string birthday, bool male, 
            string address, string password, string url, bool working, string role, int workingDays, double dayWage)
        {
            string error = null, message = null;
            bool updated = BLL.dal.ExecuteNonQuery("sp_UpdateEmployee", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("birthday", birthday),
                new SqlParameter("address", address),
                new SqlParameter("gender", male),
                new SqlParameter("phoneNumber", phoneNumber),
                new SqlParameter("salary", dayWage),
                new SqlParameter("workingDays", workingDays),
                new SqlParameter("password", password),
                new SqlParameter("role", role),
                new SqlParameter("state", working),
                new SqlParameter("photo", url));
            if (error != null)
                return "Update failed!\n" + error;
            if (!updated)
                return "No data is updated!";
            return "Update successful!";
        }

        public string DeleteEmployee(int id)
        {
            string error = null, message = null;
            bool delete = BLL.dal.ExecuteNonQuery("sp_DeleteEmployee", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id));
            if (error != null)
                return "Delete failed!\n" + error;
            if (!delete)
                return "No data is delete!";
            return "Delete successful!";
        }

        public string DisableEmployeeAccount(int id)
        {
            string error = null, message = null;
            bool disable = BLL.dal.ExecuteNonQuery("sp_UpdateEmployee", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("id", id),
                new SqlParameter("state", false));
            if (error != null)
                return "Disable failed!\n" + error;
            if (!disable)
                return "No data is disable!";
            return "Disable successful!";
        }

        public string AddEmployee(string name, string birthday, string address, bool male, string phoneNumber, string role, string url)
        {
            string error = null, message = null;
            bool insert = BLL.dal.ExecuteNonQuery("sp_InsertEmployee", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("name", name),
                new SqlParameter("birthday", birthday),
                new SqlParameter("address", address),
                new SqlParameter("gender", male),
                new SqlParameter("phoneNumber", phoneNumber),
                new SqlParameter("role", role),
                new SqlParameter("photo", url));
            if (error != null)
                return "Insert failed!\n" + error;
            if (message.Contains("hone number"))
                return "Insert failed!\n" + message;
            if (!insert)
                return "No data is insert!";
            return "Insert successful!";
        }
    }
}
