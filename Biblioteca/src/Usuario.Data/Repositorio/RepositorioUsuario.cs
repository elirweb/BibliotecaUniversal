using System;

namespace Usuario.Data.Repositorio
{
    public class RepositorioUsuario : Domain.Interfaces.Repositorios.IRepositorioUsuario
    {

        private readonly Contexto.Contexto contexto;
        public RepositorioUsuario(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Domain.Entidade.Usuario usuario)
        {
            //throw new NotImplementedException();
        }
    }
}
