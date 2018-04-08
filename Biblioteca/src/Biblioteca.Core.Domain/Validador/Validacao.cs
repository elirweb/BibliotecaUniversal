using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Core.Domain.Erros;

namespace Biblioteca.Core.Domain.Validador
{
    public class Validacao<T> : IHandler<T>
    {
        public Erros.Erros erro { get; } = new Erros.Erros();
        public  void Validar() {  }
        public bool EhValido()
        {
            return !erro.TemErro; 
        }

        public void Falhou(bool condicao, ErroDescricao descerro)
        {
            if (condicao) 
                erro.Incluir(descerro);
        }

        public virtual void  Validar(T model) { }

    }
}
