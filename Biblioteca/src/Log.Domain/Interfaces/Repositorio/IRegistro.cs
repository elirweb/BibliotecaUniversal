
using System.Collections.Generic;

namespace Log.Domain.Interfaces.Repositorio
{
    public interface IRegistro<T> where T:class 
    {
        void Adicionar(Domain.Entidade.Registro T);
        IEnumerable<Domain.Entidade.Registro> ObterRegistro();
    }
}
