using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Validador
{
    public class ValidacaoResultado
    {
        
        public List<Erros.ErroValidacao> Erros { set; get; }
        
        public ValidacaoResultado()
        {
            Erros = new List<Domain.Erros.ErroValidacao>();
        }
       }
}
