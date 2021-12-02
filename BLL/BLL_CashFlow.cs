using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_CashFlow
    {
        public DataTable GetCashFlowTable(ref string error)
        {
            return BLL.dal.ExecuteQueryData("sp_GetCashFlow", CommandType.StoredProcedure, ref error);
        }

        public object GetRevenue()
        {
            string error = null;
            return BLL.dal.ExecuteScalar("select dbo.ft_GetMonthAmount(@income)", CommandType.Text, ref error,
                new SqlParameter("income", true));
        }

        public object GetSpend()
        {
            string error = null;
            return BLL.dal.ExecuteScalar("select dbo.ft_GetMonthAmount(@income)", CommandType.Text, ref error,
                new SqlParameter("income", false));
        }
    }
}
