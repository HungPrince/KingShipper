﻿using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace KingShipper.Library
{
    public class Utility
    {
        public static string ToSHA512(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            using (SHA512 shaManaged = new SHA512Managed())
            {
                var bytes = Encoding.ASCII.GetBytes(text);
                return BitConverter.ToString(new SHA512Managed().ComputeHash(bytes)).Replace("-", "");
            }
        }

        //public static string MD5Hash(string text)
        //{
        //    MD5 md5 = MD5.Create();
        //    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
        //    byte[] result = md5.Hash;
        //    StringBuilder strBuilder = new StringBuilder();
        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        strBuilder.Append(result[i].ToString("x2"));
        //    }
        //    return strBuilder.ToString();
        //}
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "geneva";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "geneva";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}
