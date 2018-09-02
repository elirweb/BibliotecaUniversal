using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Core.Domain.Util
{
    public  class Descriptografar
    {
        private static string cryptoKey = ConfigurationManager.AppSettings["KeyCript"];
        private static byte[] bIV =
{ 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        public  static string Descript(string conexao) {
            try
            {
                if (!string.IsNullOrEmpty(conexao))
                {
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                 
                    byte[] bText = Convert.FromBase64String(conexao);
                    
                    Rijndael rijndael = new RijndaelManaged();

                    rijndael.KeySize = 256;

                    MemoryStream mStream = new MemoryStream();

                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    decryptor.Write(bText, 0, bText.Length);
                    decryptor.FlushFinalBlock();
                    UTF8Encoding utf8 = new UTF8Encoding();
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }
    }
}
