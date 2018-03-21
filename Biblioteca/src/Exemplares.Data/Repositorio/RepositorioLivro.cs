using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exemplares.Domain.Entidade;

namespace Exemplares.Data.Repositorio
{
    public class RepositorioLivro : Domain.Interfaces.Repositorios.ILivro
    {

        public RepositorioLivro()
        {

        }
        public void Adicionar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> ObterLivro()
        {
            throw new NotImplementedException();
        }
    }
}
