using Biblioteca.Core.Domain.Helper;
using System;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioLivro : Biblioteca.Core.Domain.Util.Dispose, Domain.Interfaces.IRepositorios.IRepositorioLivro
    {
        private Contexto.Contexto contexto;
        private DbHelper helper = new DbHelper();
        public RepositorioLivro(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Domain.Entidades.Livro lv)
        {
            contexto.Livro.Add(lv);
        }
        
        public bool EstaAtiva(Domain.Entidades.Livro model)
        {
            var obj = helper.ExecuteScalar($"SELECT Titulo FROM Livro lv INNER JOIN Bibliotecaria bib on bib.Id = lv.IdBiblioteca WHERE bib.Situacao = 1 ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public bool TituloUnico(Domain.Entidades.Livro lv)
        {
            var obj = helper.ExecuteScalar($"SELECT Titulo FROM Livro WHERE Titulo = '{lv.Titulo}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
    }
}
