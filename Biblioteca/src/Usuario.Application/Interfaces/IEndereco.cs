using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.Interfaces
{
    public interface IEndereco
    {
        void Adicionar(ViewModel.EnderecoUsuario endereco);
    }
}
