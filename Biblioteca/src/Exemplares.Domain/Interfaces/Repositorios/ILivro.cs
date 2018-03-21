using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplares.Domain.Interfaces.Repositorios
{
    public interface ILivro
    {
        void Adicionar(Domain.Entidade.Livro livro);
        IEnumerable<Domain.Entidade.Livro> ObterLivro();
    }
}
