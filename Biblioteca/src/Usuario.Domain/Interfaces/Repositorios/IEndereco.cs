using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.Interfaces.Repositorios
{
    public interface IEndereco
    {
        void Adicionar(Entidades.Endereco endereco);
    }
}
