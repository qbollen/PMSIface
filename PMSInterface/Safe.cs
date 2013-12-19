using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Utils;

namespace PMSInterface
{
    class Safe
    {
        private SqlHelper sqlHelper = new SqlHelper();

        public string DecryptDES(string encrypt, string iv, string decryptKey)
        {

            string[] sInput = encrypt.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(iv);
                byte[] inputByteArray = data;
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(
                    mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return null;
            }
        }

        public DateTime GetDateTimeFromDecrypt(bool isFromDb, string encrypt = "")
        {
            DateTime dateTime = new DateTime(2000, 1, 1,1,1,1);
            string sEncrypt = encrypt;
            try
            {
                if (isFromDb)
                {
                    string sql = "select RegisteNO from Registe";
                    sqlHelper.CurrConn = DbType.Local;
                    string regNo = sqlHelper.ExecuteScalar(sql, null).ToString();
                    if (regNo == "0")
                    {
                        return dateTime;
                    }

                    sEncrypt = regNo;
                }

                DateTime newDateTime = DateTime.ParseExact(DecryptDES(sEncrypt, "ORBITATech", "OBTIF13D"), "yyyyMMddHHmmss",
                        System.Globalization.CultureInfo.InvariantCulture);
                dateTime = newDateTime;
            }
            catch
            {
                return dateTime;
            }

            return dateTime;
        }
    }
}
