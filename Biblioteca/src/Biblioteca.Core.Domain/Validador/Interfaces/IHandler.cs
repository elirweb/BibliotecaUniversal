using Biblioteca.Core.Domain.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Validador.Interfaces
{
    public interface IHandler<T>
    {
        void Falhou(bool condicao, ErroDescricao erro,string _usuario);

        bool EhValido();

       
    }
}
