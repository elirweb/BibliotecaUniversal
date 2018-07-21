using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.Interfaces
{
    public interface IEndereco
    {
        void Adicionar(ViewModel.Endereco endereco);
        void Add(ViewModel.Endereco end, ViewModel.Bibliotecaria bi,string token,out string retorno);
    }
}
