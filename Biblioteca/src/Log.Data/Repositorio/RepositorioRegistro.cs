
using System;
using System.Collections.Generic;
using Log.Domain.Entidade;

namespace Log.Data.Repositorio
{
    public class RepositorioRegistro : Domain.Interfaces.Repositorio.IRegistro
    {
        public RepositorioRegistro()
        {

        }
        public void Adicionar(Registro reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
