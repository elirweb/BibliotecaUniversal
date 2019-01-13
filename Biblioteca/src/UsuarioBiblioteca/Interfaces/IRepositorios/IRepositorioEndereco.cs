using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Domain.Interfaces.IRepositorios
{
    public interface IRepositorioEndereco:IDisposable
    {
        void Adicionar(Entidades.Endereco endereco);
        void Atualizar(Entidades.Endereco endereco);
         
    }
}
