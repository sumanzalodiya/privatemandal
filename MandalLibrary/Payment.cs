using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public class Payment
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        SqlTransaction sqlTxn = null;
        DataSet dst = null;

        public DataSet GetPendingPayments(int intMemberNumber,int isAdvanceLoanPayment)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_PENDING_PAYMENTS", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MEMBER_ID", intMemberNumber);
                sqlCmd.Parameters.AddWithValue("@IS_ADVANCE_LOAN_PAYMENT", isAdvanceLoanPayment);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_PENDING_PAYMENTS", "", "GetPendingPayments");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_PENDING_PAYMENTS", ex.Message, "GetPendingPayments");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public bool AddPayment(string strXML, int intNumberOfRows,out string strPaymentId)
        {
            SqlCommand sqlCmd = new SqlCommand("ADD_PAYMENT", sqlCon);
            int intNoOfRows = 0;
            bool blnSuccess = false;
            strPaymentId = string.Empty;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                SqlParameter sqlPaymentId = new SqlParameter("@PAYMENT_RECEIPT_ID", SqlDbType.VarChar, 8);
                sqlPaymentId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlPaymentId);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (intNoOfRows == intNumberOfRows)
                {
                    sqlTxn.Commit();
                    blnSuccess = true;
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
                LogError.LogEvent("ADD_PAYMENT --> " + strXML, ex.Message, "AddPayment");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public DataSet GetPaymentReceipt(string receiptNumber)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_PAYMENT_RECEIPT", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PAYMENT_RECEIPT_ID", receiptNumber);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_PAYMENT_RECEIPT", "", "GetPaymentReceipt");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_PAYMENT_RECEIPT", ex.Message, "GetPaymentReceipt");
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
