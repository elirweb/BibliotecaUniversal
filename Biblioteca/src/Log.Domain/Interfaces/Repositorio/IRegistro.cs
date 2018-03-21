
using System.Collections.Generic;

namespace Log.Domain.Interfaces.Repositorio
{
    public interface IRegistro
    {
        void Adicionar(Domain.Entidade.Registro reg);
        IEnumerable<Domain.Entidade.Registro> ObterRegistro();
    }
}
