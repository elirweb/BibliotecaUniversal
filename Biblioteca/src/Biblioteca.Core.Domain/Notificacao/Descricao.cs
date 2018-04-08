using Biblioteca.Core.Domain.Interfaces.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Notificacao
{
    public class Descricao : IDescricao
    {
        public string Menssage { get; }

        public Descricao(string message, params string[] args)
        {
            Menssage = message;

            for (var i = 0; i < args.Length; i++)
            {
                Menssage = Menssage.Replace("{" + i + "}", args[i]);
            }
        }

        public override string ToString()
        {
            return Menssage;
        }
    }
}
