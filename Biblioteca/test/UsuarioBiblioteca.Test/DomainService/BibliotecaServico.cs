using UsuarioBiblioteca.Test.Entidades;
using UsuarioBiblioteca.Test.Interfaces;

namespace UsuarioBiblioteca.Test.DomainService
{
    public class BibliotecaServico: IBiblioteca
    {
        private readonly IBibliotecaRepositorio repositorio;
        public BibliotecaServico(IBibliotecaRepositorio repo)
        {
            repositorio = repo;
        }

        public void AdicionarBiblioteca(Entidades.Bibliotecaria u)
        {
            repositorio.AdicionarBiblioteca(u);
        }

        public RetornoMsg RetornaSucesso(Entidades.Bibliotecaria bi)
        {

            if (bi == null) return new RetornoMsg("Erro na gravação de dados");
            return new RetornoMsg("Dados Gravado com sucesso", bi.Id);
        }
    }
}
