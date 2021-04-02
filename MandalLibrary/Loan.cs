using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public class Loan
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        SqlTransaction sqlTxn = null;
        DataSet dst = null;

        public bool AddNewLoanApplication(string strXML)
        {
            SqlCommand sqlCmd = new SqlCommand("ADD_LOAN_APPLICATION", sqlCon);
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
                if (intNoOfRows == 1)
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
                LogError.LogEvent("ADD_LOAN_APPLICATION --> " + strXML, ex.Message, "AddNewLoanApplication");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public DataSet GetLoanApplicationList(int intMonth, int intYear,string strAll)
        {
            string strSQL = "SELECT MEMBER_NAME, MEMBER_VILLAGE, MEMBER_ID, APP_ID " +
                                               "FROM LOAN_APPLICATION " +
                                               "INNER JOIN MEMBER_MASTER ON MEMBER_ID = APP_MEMBER_ID" + "" +
                                               " WHERE APP_MONTH=" + intMonth.ToString() + " AND APP_YEAR=" + intYear.ToString();

            if(strAll=="YES")
            {
                strSQL += " AND APP_TAKEN=0";
            }
            SqlCommand sqlCmd = new SqlCommand(strSQL , sqlCon);
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent(sqlCmd.CommandText, "", "GetLoanApplicationList");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent(sqlCmd.CommandText, ex.Message, "GetLoanApplicationList");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public bool AddNewLoan(string strXML,int intNoOfRows, out int intLoanId, out string strPaymentId)
        {
            SqlCommand sqlCmd = new SqlCommand("ADD_NEW_LOAN", sqlCon);
            int intNoOfRowsAffected = 0;
            intLoanId = 0;
            bool blnSuccess = false;
            strPaymentId = string.Empty;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                SqlParameter sqlLoanId = new SqlParameter("@LOAN_ID", SqlDbType.Int);
                sqlLoanId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlLoanId);
                SqlParameter sqlPaymentId = new SqlParameter("@PAYMENT_RECEIPT_ID", SqlDbType.VarChar, 8);
                sqlPaymentId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlPaymentId);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRowsAffected = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (intNoOfRowsAffected >= intNoOfRows)
                {
                    sqlTxn.Commit();
                    blnSuccess = true;
                    intLoanId = Convert.ToInt32(sqlLoanId.Value);
                    strPaymentId = sqlPaymentId.Value.ToString();
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
                LogError.LogEvent("ADD_NEW_LOAN --> " + strXML, ex.Message, "AddNewLoan");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public bool CheckLoanRunning(int intMemberId)
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) FROM LOAN_MASTER WHERE LOAN_PENDING_AMOUNT>0 AND LOAN_MEMBER_ID=@MEMBER_ID", sqlCon);
            int intNoOfRows = 0;
            bool blnRunning = false;
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@MEMBER_ID", intMemberId);
                sqlCon.Open();
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (intNoOfRows >= 1)
                {
                    blnRunning = true;
                }
            }
            catch (Exception ex)
            {
                blnRunning = false;
                LogError.LogEvent(sqlCmd.CommandText, ex.Message, "CheckLoanRunning");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnRunning;
        }

        public DataSet GetLoanDetails(int intLoanId)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_LOAN_DETAILS", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@LOAN_ID", intLoanId);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_LOAN_DETAILS", "", "GetLoanDetails");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_LOAN_DETAILS", ex.Message, "GetLoanDetails");
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
