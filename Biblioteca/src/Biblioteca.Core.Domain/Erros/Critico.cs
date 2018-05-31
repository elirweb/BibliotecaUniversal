using Biblioteca.Core.Domain.Interfaces.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Erros
{
    public class Critico : INivel
    {
        public string Descricao { get; }

        public Critico(string descricao = "critico")
        {
            Descricao = descricao; //elir
        }

        public override string ToString()
        {
            return Descricao;
        }

    }
}
