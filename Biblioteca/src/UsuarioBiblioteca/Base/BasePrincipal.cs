using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Domain.Base
{
    public class BasePrincipal
    {
        public Guid Id { get;  set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtUltmaAlteracao { get; private set; }
        public TimeSpan HoraCadastro { get;  set; }
        public TimeSpan? HoraVisualizacao { get; private set; }

    }
}
