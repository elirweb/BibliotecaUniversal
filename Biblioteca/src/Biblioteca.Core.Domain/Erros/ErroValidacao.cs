using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Erros
{
    public class ErroValidacao
    {
        public ErroValidacao(string mensagem,string grupo)
        {
            Menssage = mensagem;
            DtaError = DateTime.Now;
            Grupo = grupo;
        }
        public string Menssage { get; set; }

        public DateTime DtaError { get; set; }

        public string Grupo { get; set; }

    }
}
