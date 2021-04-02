using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public class Report
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        DataSet dst = null;

        public DataSet GetPendingLoanList()
        {
            SqlCommand sqlCmd = new SqlCommand("GET_PENDING_LOAN_LIST", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_PENDING_LOAN_LIST", "", "GetPendingLoanList");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_PENDING_LOAN_LIST", ex.Message, "GetPendingLoanList");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetPendingLoanApplicationList()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT MEMBER_NAME,MEMBER_VILLAGE,CONVERT(VARCHAR,APP_DATE,103) AS APPLICATION_DATE,DATENAME(MONTH,CONVERT(DATE,'01/' + CONVERT(VARCHAR,APP_MONTH) + '/1900',103)) + ' - ' + CONVERT(VARCHAR,APP_YEAR) AS REQUIRED_ON FROM LOAN_APPLICATION INNER JOIN MEMBER_MASTER ON MEMBER_ID=APP_MEMBER_ID WHERE APP_TAKEN='0'", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent(sqlCmd.CommandText, "", "GetPendingLoanApplicationList");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent(sqlCmd.CommandText, ex.Message, "GetPendingLoanApplicationList");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetMonthlyPaymentList(int intMonth, int intYear)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_MONTHLY_PAYMENT_LIST", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MONTH", intMonth);
                sqlCmd.Parameters.AddWithValue("@YEAR", intYear);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_MONTHLY_PAYMENT_LIST", "", "GetMonthlyPaymentList");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_MONTHLY_PAYMENT_LIST", ex.Message, "GetMonthlyPaymentList");
            }
            finally
            {                
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetPaymentReport(string fromDate, string toDate, string type)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_PAYMENT_REPORT", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FROM_DATE", fromDate);
                sqlCmd.Parameters.AddWithValue("@TO_DATE", toDate);
                sqlCmd.Parameters.AddWithValue("@TYPE", type);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_PAYMENT_REPORT", "", "GetPaymentReport");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_PAYMENT_REPORT", ex.Message, "GetPaymentReport");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetExpenseReport(string fromDate, string toDate)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_EXPENSE_REPORT", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FROM_DATE", fromDate);
                sqlCmd.Parameters.AddWithValue("@TO_DATE", toDate);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_EXPENSE_REPORT", "", "GetExpenseReport");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_EXPENSE_REPORT", ex.Message, "GetExpenseReport");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetMonthlySummaryReport(int intMonth, int intYear)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_MONTHLY_SUMMARY", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MONTH", intMonth);
                sqlCmd.Parameters.AddWithValue("@YEAR", intYear);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_MONTHLY_SUMMARY", "", "GetMonthlySummaryReport");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_MONTHLY_SUMMARY", ex.Message, "GetMonthlySummaryReport");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetYearlySummaryReport(int intYear)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_YEARLY_SUMMARY", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@YEAR", intYear);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_YEARLY_SUMMARY", "", "GetYearlySummaryReport");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_YEARLY_SUMMARY", ex.Message, "GetYearlySummaryReport");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public bool TakeDBBackup()
        {
            bool blnSuccess = false;
            SqlCommand sqlCmd = new SqlCommand("TAKE_DB_BACKUP", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            catch (Exception ex)
            {
                blnSuccess = false;
            }
            finally
            {
                sqlCon.Close();
            }
            return blnSuccess;
        }
    }
}
