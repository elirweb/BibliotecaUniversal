using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain.Entidade;

namespace Usuario.Domain.Especificacao
{
    public class UsuarioDevePossuirUnicoLogin : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Entidade.Usuario>
    {
        private readonly Interfaces.Repositorios.IRepositorioUsuario repositorio;

        public UsuarioDevePossuirUnicoLogin(Interfaces.Repositorios.IRepositorioUsuario repo)
        {
            repositorio = repo;
        }
        public bool InSatisfeito(Entidade.Usuario model)
        {
            return repositorio.loginunico(model);
        }
    }
}
