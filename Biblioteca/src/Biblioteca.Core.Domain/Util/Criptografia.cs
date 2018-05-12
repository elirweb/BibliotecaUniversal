﻿using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Core.Domain.Util
{
    public static class Criptografia
    {
        private static byte[] bIV =
   { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
        private static string cryptoKey = ConfigurationManager.AppSettings["KeyCript"];

        public static string Encriptar(string conexao) {
            try
            {
                if (!string.IsNullOrEmpty(conexao))
                {
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(conexao);

                    Rijndael rijndael = new RijndaelManaged();

                    rijndael.KeySize = 256;

                    MemoryStream mStream = new MemoryStream();
                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    encryptor.Write(bText, 0, bText.Length);
                    encryptor.FlushFinalBlock();
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else {
                    return null;
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException("Erro ao criptografar", e);
            }
            
        }

    }

}