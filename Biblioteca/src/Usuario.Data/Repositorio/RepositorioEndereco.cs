using System;
using Usuario.Domain.Entidade;

namespace Usuario.Data.Repositorio
{
    public class RepositorioEndereco : Biblioteca.Core.Domain.Util.Dispose, Domain.Interfaces.Repositorios.IRepositorioEndereco
    {
        private Contexto.Contexto contexto;
        public RepositorioEndereco(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(EnderecoUsuario endereco)
        {
            contexto.EnderecoUsuario.Add(endereco);
        }

     
        
    }
}
