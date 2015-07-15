using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;

namespace Wifi_Share
{
    public class EncryptDecryptDES
    {
        static internal string EncryptString(string sInput,string sKey)
        {
            //创建加密器对象
            try
            {
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.UTF8.GetBytes(sKey.Substring(0,8));
                DES.IV = ASCIIEncoding.UTF8.GetBytes(sKey.Substring(0,8));
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                //加密字符串
                MemoryStream sEncrypted = new MemoryStream();
                CryptoStream cryptostream = new CryptoStream(sEncrypted,
                    desencrypt,
                    CryptoStreamMode.Write);
                byte[] bytearrayinput = ASCIIEncoding.UTF8.GetBytes(sInput);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.FlushFinalBlock();
                return Convert.ToBase64String(sEncrypted.ToArray());
            }
            catch
            {
                return sInput;
            }
        }

        static internal string DecryptString(string sInput, string sKey)
        {
            try
            {
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                //A 64 bit key and IV is required for this provider.
                //Set secret key For DES algorithm.
                DES.Key = ASCIIEncoding.UTF8.GetBytes(sKey.Substring(0,8));
                //Set initialization vector.
                DES.IV = ASCIIEncoding.UTF8.GetBytes(sKey.Substring(0,8));
                //Create a DES decryptor from the DES instance.
                ICryptoTransform desdecrypt = DES.CreateDecryptor();

                //Create a stream to read the encrypted string.
                MemoryStream sDecrypted = new MemoryStream();
                //Create crypto stream set to read and do a 
                //DES decryption transform on incoming bytes.
                CryptoStream cryptostreamDecr = new CryptoStream(sDecrypted,
                    desdecrypt,
                    CryptoStreamMode.Write);
                byte[] bytearrayinput = Convert.FromBase64String(sInput);
                cryptostreamDecr.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostreamDecr.FlushFinalBlock();
                return ASCIIEncoding.UTF8.GetString(sDecrypted.ToArray());
            }
            catch
            {
                return sInput;
            }
        } 
    }
}

