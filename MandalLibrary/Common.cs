using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public class Common
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        SqlTransaction sqlTxn = null;
        DataSet dst = null;

        public DataSet GetMandalDetails()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM MANDAL_DETAILS", sqlCon);
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst, "Mandal");
                LogError.LogEvent("SELECT * FROM MANDAL_DETAILS", "", "GetMandalDetails");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("SELECT * FROM MANDAL_DETAILS", ex.Message, "GetLastNumber");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public decimal GetMandalBalance(int intMonth, int intYear)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_MANDAL_BALANCE", sqlCon);
            decimal dcmlBalance = 0;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MONTH", intMonth);
                sqlCmd.Parameters.AddWithValue("@YEAR", intYear);
                sqlCon.Open();
                dcmlBalance = Convert.ToDecimal(sqlCmd.ExecuteScalar());
                LogError.LogEvent("GET_MANDAL_BALANCE", "", "GetMandalDetails");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_MANDAL_BALANCE", ex.Message, "GetMandalBalance");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dcmlBalance;
        }

        public bool AddNewExpense(string strXML)
        {
            SqlCommand sqlCmd = new SqlCommand("ADD_NEW_EXPENSE", sqlCon);
            int intNoOfRows = 0;
            bool blnSuccess = false;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (intNoOfRows == 2)
                {
                    sqlTxn.Commit();
                    blnSuccess = true;
                }
                else
                {
                    sqlTxn.Rollback();
                }
            }
            catch (Exception ex)
            {
                blnSuccess = false;
                sqlTxn.Rollback();
                LogError.LogEvent("ADD_NEW_EXPENSE --> " + strXML, ex.Message, "AddNewExpense");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public DataSet GetDashboardData()
        {
            SqlCommand sqlCmd = new SqlCommand("GET_DASHBOARD_DATA", sqlCon);
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_DASHBOARD_DATA", "", "GetDashboardData");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_DASHBOARD_DATA", ex.Message, "GetDashboardData");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }
    }
}
