using Biblioteca.Core.Domain.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioLivro : Biblioteca.Core.Domain.Util.DisposeElement, Domain.Interfaces.IRepositorios.IRepositorioLivro
    {
        private Contexto.Contexto _contexto;
        private DbHelper _helper = new DbHelper();
        public RepositorioLivro(Contexto.Contexto coc)
        {
            _contexto = coc;
        }
        public void Adicionar(Domain.Entidades.Livro lv)
        {
            _contexto.Livro.Add(lv);
        }

        public void Atualizar(Livro model)
        {
            _contexto.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<object> DadosLivro(string parameter)
        {
            var query = "SELECT Titulo,QtdPg,Editora,Ativo,Descricao,Categoria  FROM Livro INNER JOIN Bibliotecaria ON Bibliotecaria.IdBiblioteca = Livro.IdBiblioteca WHERE Bibliotecaria.Cnpj = @parameter";
            return _helper.ExecuteList(query, parameter, _contexto.Database.Connection);
        }

        public bool EstaAtiva(Domain.Entidades.Livro model)
        {
            var obj = _helper.ExecuteScalar($"SELECT Titulo FROM Livro lv INNER JOIN Bibliotecaria bib on bib.Id = lv.IdBiblioteca WHERE bib.Situacao = 1 ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public void Excluir(Livro model)
        {
            _contexto.Entry(model).State = EntityState.Deleted;
        }

        public bool TituloUnico(Domain.Entidades.Livro lv)
        {
            var obj = _helper.ExecuteScalar($"SELECT Titulo FROM Livro WHERE Titulo = '{lv.Titulo}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
    }
}
