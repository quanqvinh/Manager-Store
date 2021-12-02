using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Login
    {
        public void ChangeRole(string role)
        {
            BLL.dal = new DataAccess(role);
        }

        public string CheckAccountInfo(string phoneNumber, string password, ref string error)
        {
            string sql = "select dbo.ft_CheckLogin(@phoneNumber, @password)";
            return BLL.dal.ExecuteScalar(sql, CommandType.Text, ref error,
                new SqlParameter("phoneNumber", phoneNumber),
                new SqlParameter("password", password)).ToString();
        }

        public string InsertLoginTime(int eid)
        {
            string error = null, message = null;
            string day = DateTime.Now.ToString("yyyy-MM-dd");
            bool inserted = BLL.dal.ExecuteNonQuery("sp_InsertLogin", CommandType.StoredProcedure, ref error, ref message,
                new SqlParameter("day", day),
                new SqlParameter("eid", eid));
            if (error != null)
                return "Insert failed!\n" + error;
            if (!inserted)
                return "Data is not inserted!";
            return "Insert successful!";
        }

        public Employee GetEmployeeProfile(int id, ref string error)
        {
            string sql = "sp_LoadProfile";
            DataTable result = BLL.dal.ExecuteQueryData(sql, CommandType.StoredProcedure, ref error, new SqlParameter("id", id));
            string name = result.Rows[0]["ename"].ToString();
            DateTime birthday = DateTime.Parse(result.Rows[0]["birthday"].ToString());
            string address = result.Rows[0]["eaddress"].ToString();
            bool male = (bool)result.Rows[0]["gender"];
            string phoneNumber = result.Rows[0]["ephoneNumber"].ToString();
            int workDays = (int)result.Rows[0]["workDays"];
            double salaryPerDay = (double)result.Rows[0]["salaryPerDay"];
            double monthSalary = (double)result.Rows[0]["monthSalary"];
            string password = result.Rows[0]["password"].ToString();
            string role = result.Rows[0]["role"].ToString();
            bool stillWork = (bool)result.Rows[0]["estate"];
            string urlImage = result.Rows[0]["ephoto"].ToString();
            return new Employee(id, name, birthday, address, male, phoneNumber, workDays, salaryPerDay, monthSalary, password, role, stillWork, urlImage);
        }
    }
}
