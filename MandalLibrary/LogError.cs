using System;
using System.Data;
using System.Data.SqlClient;

namespace MandalLibrary
{
    public static class LogError
    {
        private static SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"].ToString());
        private static SqlTransaction sqlTxn = null;

        public static string addescape(string str)
        {
            string temp = "";
            foreach (char ch in str)
            {
                if (ch == '\0')
                    temp += "";
                else if (ch == '\'')
                    temp += "&#39;";
                else if (ch == '\\')
                    temp += "&#34;";
                else if (ch == '<')
                    temp += "&lt;";
                else if (ch == '>')
                    temp += "&gt;";
                else
                    temp += ch;
            }
            return (temp);
        }

        public static void LogEvent(string strQuery, string strMessage, string strFunctionName)
        {
            int intNoOfRows = 0;
            SqlCommand sqlCmd = new SqlCommand("ADD_EVENT_LOG", sqlCon);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QUERY", addescape(strQuery));
                sqlCmd.Parameters.AddWithValue("@MSG", addescape(strMessage));
                sqlCmd.Parameters.AddWithValue("@FUNCTION", strFunctionName);

                sqlCon.Open();
                sqlTxn = sqlCon.BeginTransaction();
                sqlCmd.Transaction = sqlTxn;
                intNoOfRows = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (intNoOfRows == 1)
                {
                    sqlTxn.Commit();
                }
            }
            catch (Exception ex)
            {
                sqlTxn.Rollback();
            }
            finally
            {
                sqlCon.Close();
                sqlCmd.Parameters.Clear();
            }
        }
    }
}
