using System;
using System.Security.Cryptography;
using System.Text;

namespace PrivateMandal
{
    public static class LoginDetails
    {
        public static string userID { get; set; }
        public static string userName { get; set; }
        public static string strForms { get; set; }
        public static string GetFiscalYear(DateTime fiscalYearDate)
        {
            string fiscalYear = string.Empty;
            int currntYear = fiscalYearDate.Year;
            int prevYear = fiscalYearDate.Year - 1;
            int nextYear = fiscalYearDate.Year + 1;
            int month = fiscalYearDate.Month;
            if (month > 3)
                fiscalYear = currntYear.ToString() + "-" + nextYear.ToString();
            else
                fiscalYear = prevYear.ToString() + "-" + currntYear.ToString();
            return fiscalYear;
        }

        public static string GetSafeXMLString(string strValue)
        {
            strValue = strValue.Replace("'", "&#39;");
            strValue = strValue.Replace("\\", "&#34;");
            strValue = strValue.Replace("<", "&lt;");
            strValue = strValue.Replace(">", "&gt;");
            strValue = strValue.Replace("\"", "&quot;");
            return strValue;
        }
    }

    public class CryptoEngine
    {
        public static string Encrypt(string toEncrypt, bool blnUseHash)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            string key = "Mjdw0JHjw0Amw";
            if (blnUseHash)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool blnUseHash)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(cipherString);
            string key = "Mjdw0JHjw0Amw";
            if (blnUseHash)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
