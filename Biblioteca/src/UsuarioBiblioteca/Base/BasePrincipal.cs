using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Base
{
    public class BasePrincipal
    {
        public Guid Id { get; private set; }
        public DateTime DtCadastro { get; private set; }
        public DateTime? DtUltmaAlteracao { get; private set; }
        public TimeSpan HoraCadastro { get; private set; }
        public TimeSpan? HoraVisualizacao { get; private set; }

    }
}
