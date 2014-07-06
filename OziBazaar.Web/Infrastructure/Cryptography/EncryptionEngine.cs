﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OziBazaar.Web.Infrastructure.Cryptography
{
    public class EncryptionEngine : IEncryptionEngine
    {
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";

        public string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {
            byte[] key;
            byte[] IV;
            byte[] inputByteArray;
            try
            {
                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                stringToDecrypt = stringToDecrypt.Replace(" ", "+");
                int len = stringToDecrypt.Length;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8; 
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {
            byte[] key;
            byte[] IV;
            byte[] inputByteArray;
            try
            {
                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(); 
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private byte[] Convert2ByteArray(string strInput)
        {
            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();
            byte[] arrByte = new byte[arrChar.Length];
            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);
            return arrByte;
        }
    }
}