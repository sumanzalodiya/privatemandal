using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public class Member
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        SqlTransaction sqlTxn = null;
        DataSet dst = null;

        public DataSet GetAutoSuggestData(string strType)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_AUTOPOPULATE_DATA", sqlCon);
            DataSet dstAuto = new DataSet();
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TYPE", strType);

                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dstAuto);
                LogError.LogEvent("GET_AUTOPOPULATE_DATA --> " + strType,"","GetAutoSuggestData");
            }
            catch (Exception ex)
            {
                dstAuto = null;
                LogError.LogEvent("GET_AUTOPOPULATE_DATA --> " + strType, ex.Message, "GetAutoSuggestData");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dstAuto;
        }

        public bool AddNewMember(string strXML, out int intMemberNo, byte[] photo, out int intLoanId,out string strPaymentId)
        {
            SqlCommand sqlCmd = new SqlCommand("ADD_NEW_MEMBER", sqlCon);
            int intNoOfRows = 0;
            bool blnSuccess = false;
            intMemberNo = 0;
            intLoanId = 0;
            strPaymentId = string.Empty;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                SqlParameter sqlMemberNum = new SqlParameter("@MEMBER_ID", SqlDbType.Int);
                sqlMemberNum.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlMemberNum);
                SqlParameter sqlLoanId = new SqlParameter("@LOAN_ID", SqlDbType.Int);
                sqlLoanId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlLoanId);
                sqlCmd.Parameters.AddWithValue("@PHOTO", photo);
                SqlParameter sqlPaymentId = new SqlParameter("@PAYMENT_RECEIPT_ID", SqlDbType.VarChar, 8);
                sqlPaymentId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(sqlPaymentId);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if(intNoOfRows >= 241)
                {
                    sqlTxn.Commit();
                    intMemberNo = Convert.ToInt32(sqlMemberNum.Value);
                    intLoanId = Convert.ToInt32(sqlLoanId.Value);
                    strPaymentId = sqlPaymentId.Value.ToString();
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
                LogError.LogEvent("ADD_NEW_MEMBER --> " + strXML, ex.Message, "AddNewMember");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public bool UpdateMemberDetails(string strXML, byte[] photo)
        {
            SqlCommand sqlCmd = new SqlCommand("UPUDATE_MEMBER_DETAILS", sqlCon);
            int intNoOfRows = 0;
            bool blnSuccess = false;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                sqlCmd.Parameters.AddWithValue("@PHOTO", photo);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (intNoOfRows ==1)
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
                LogError.LogEvent("UPUDATE_MEMBER_DETAILS --> " + strXML, ex.Message, "UpdateMemberDetails");
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return blnSuccess;
        }

        public DataSet GetMemberList(string strType)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_MEMBER_LIST", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TYPE", strType);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_MEMBER_LIST", "", "GetMemberList");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_MEMBER_LIST", ex.Message, "GetMemberList");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet GetMemberDetails(int intMemberId)
        {
            SqlCommand sqlCmd = new SqlCommand("GET_MEMBER_DETAILS", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MEMBER_ID", intMemberId);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("GET_MEMBER_DETAILS", "", "GetMemberDetails");
            }
            catch (Exception ex)
            {
                dst = null;
                LogError.LogEvent("GET_MEMBER_DETAILS", ex.Message, "GetMemberDetails");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public DataSet ValidateUser(string strUserID, string strPass)
        {
            SqlCommand sqlCmd = new SqlCommand("VALIDATE_USER", sqlCon);
            try
            {
                sqlCmd.Parameters.AddWithValue("@USER_ID", strUserID);
                sqlCmd.Parameters.AddWithValue("@PASSWORD", strPass);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent("VALIDATE_USER --> " + strUserID + "," + strPass,"","ValidateUuser");
            }
            catch (Exception ex)
            {
                dst = new DataSet();
                dst = null;
                LogError.LogEvent("VALIDATE_USER --> " + strUserID + "," + strPass, ex.Message, "ValidateUuser");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public int ChangeUserPassword(string strXML)
        {
            int intNoOfRows = 0;
            SqlCommand sqlCmd = new SqlCommand("CHANGE_PASSWORD", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@STRXML", strXML);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (intNoOfRows == 2)
                {
                    sqlTxn.Commit();
                }
                else if (intNoOfRows == 1)
                {
                    sqlTxn.Rollback();
                }
                else
                {
                    sqlTxn.Rollback();
                }
            }
            catch (Exception ex)
            {
                sqlTxn.Rollback();
                LogError.LogEvent("CHANGE_PASSWORD -->" + strXML.ToString(), ex.Message,"ChangePwd");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return intNoOfRows;
        }

        public DataSet GetEMIHistory()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT CONVERT(VARCHAR,EMI_FROM_DATE,105) AS EMI_DATE,EMI_AMOUNT FROM MONTHLY_EMI_HISTORY ORDER BY EMI_FROM_DATE", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                dst = new DataSet();
                sqlDa.Fill(dst);
                LogError.LogEvent(sqlCmd.CommandText, "", "GetEMIHistory");
            }
            catch (Exception ex)
            {
                dst = new DataSet();
                dst = null;
                LogError.LogEvent(sqlCmd.CommandText, ex.Message, "GetEMIHistory");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return dst;
        }

        public int ChangeEMImount(int month, int year, decimal dcmlAmount)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE_EMI_AMOUNT", sqlCon);
            int intResult = 0;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MONTH", month);
                sqlCmd.Parameters.AddWithValue("@YEAR", year);
                sqlCmd.Parameters.AddWithValue("@AMOUNT", dcmlAmount);
                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intResult = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (intResult == 1)
                {
                    sqlTxn.Commit();
                }
                else
                {
                    sqlTxn.Rollback();
                }
            }
            catch (Exception ex)
            {
                sqlTxn.Rollback();
                LogError.LogEvent("UPDATE_EMI_AMOUNT", ex.Message, "ChangeEMImount");
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
            return intResult;
        }
    }
}
