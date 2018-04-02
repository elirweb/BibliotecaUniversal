using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class EnderecoApp : Interfaces.IEndereco
    {
        private readonly IRepositorioEndereco repositorio;

        public EnderecoApp(IRepositorioEndereco end)
        {
            repositorio = end;
        }
        public void Adicionar(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
