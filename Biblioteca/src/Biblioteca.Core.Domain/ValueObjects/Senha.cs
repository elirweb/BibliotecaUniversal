using System;
using System.Text;

namespace Biblioteca.Core.Domain.ValueObjects
{
    public class Senha
    {
        public string CodigoSenha { get; private set; }

        public Senha(string codigo, string confirmasenha)
        {
            if (codigo.Equals(confirmasenha))
                CodigoSenha = CalculateSHA1(codigo, Encoding.UTF32);

        }

        public static string CalculateSHA1(string text, Encoding enc)
        {
            try
            {
                byte[] buffer = enc.GetBytes(text);
                System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
    }
}

