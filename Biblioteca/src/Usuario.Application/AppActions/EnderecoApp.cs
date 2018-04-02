using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Application.ViewModel;
using Usuario.Domain.Interfaces.Repositorios;

namespace Usuario.Application.AppActions
{
    public class EnderecoApp : Interfaces.IEndereco
    {
        private readonly IRepositorioEndereco repositorio;

        public EnderecoApp(IRepositorioEndereco end)
        {
            repositorio = end;
        }


        public void Adicionar(EnderecoUsuario endereco)
        {
            throw new NotImplementedException();
        }
    }
}
