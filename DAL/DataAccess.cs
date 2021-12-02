using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccess
    {
        // Local variable
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter da = null;
        private string computerName = Environment.MachineName.ToString();
        private string databaseName = "GroceryStore";
        private string connectionString = "Server={0};Database={1};User Id={2};Password={3};";
        private string message = "";
        
        // Contructor
        public DataAccess(string role)
        {
            string username = string.Empty, password = string.Empty;
            if (role == "ADMIN")
            {
                username = "GS_admin";
                password = "admin";
            }
            else if (role == "STAFF")
            {
                username = "GS_staff";
                password = "staff";
            }
            else
            {
                username = "GS_stockmanager";
                password = "stockmanager";
            }
            Authorization(username, password);
        }

        // Open sql server connection
        private void Connect()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        // Authorization
        public void Authorization(string userId, string password)
        {
            string temp = string.Format(connectionString, computerName, databaseName, userId, password);
            conn = new SqlConnection(temp);
            cmd = conn.CreateCommand();
            conn.InfoMessage += new SqlInfoMessageEventHandler((object obj, SqlInfoMessageEventArgs e) => { message = e.Message; });
        }

        // Select data from database
        public DataTable ExecuteQueryData(string sql, CommandType type, ref string error, params SqlParameter[] parameters)
        {
            Connect();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            foreach (var param in parameters)
                cmd.Parameters.Add(param);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try { da.Fill(dt); }
            catch (Exception e)
            {
                error = e.Message;
                dt = null;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                da.Dispose();
                conn.Close();
            }
            return dt;
        }

        // Insert, update, delete data from database
        public bool ExecuteNonQuery(string sql, CommandType type, ref string error, ref string message, params SqlParameter[] parameters)
        {
            Connect();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            this.message = "";
            foreach (var param in parameters)
                cmd.Parameters.Add(param);
            bool check;
            try { check = cmd.ExecuteNonQuery() > 0; }
            catch (Exception e)
            {
                error = e.Message;
                check = false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
                message = this.message;
            }
            return check;
        }

        // Get returned value from function in database
        public object ExecuteScalar(string sql, CommandType type, ref string error, params SqlParameter[] parameters)
        {
            Connect();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            foreach (var param in parameters)
                cmd.Parameters.Add(param);
            object result;
            try { result = cmd.ExecuteScalar(); }
            catch (Exception e)
            {
                error = e.Message;
                result = null;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return result;
        }
    }
}
