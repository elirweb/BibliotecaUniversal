using Biblioteca.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Events
{
    public class BibliotecaCadastroEvent : IDomainEvent
    {
        public DateTime DataOcorrencia
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Versao
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
