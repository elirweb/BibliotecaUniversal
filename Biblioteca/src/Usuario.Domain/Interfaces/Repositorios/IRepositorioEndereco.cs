using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.Interfaces.Repositorios
{
    
    public interface IRepositorioEndereco
    {
        void Adicionar(Entidade.EnderecoUsuario endereco);
    }
}
