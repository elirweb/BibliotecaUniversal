
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UsuarioBiblioteca.Domain.Entidades;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioLivro : IRepositorioLivro
    {
        private Contexto.Contexto _contexto;
        private string sql = string.Empty;
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
            _contexto.SaveChanges();
        }

        

        public IEnumerable<Domain.Entidades.Livro> DadosLivro(string parameter)
        {
             sql = "SELECT Titulo,QtdPg,Editora,Ativo,Descricao,Categoria  FROM Livro INNER JOIN Bibliotecaria ON Bibliotecaria.IdBiblioteca = Livro.IdBiblioteca WHERE Bibliotecaria.Cnpj = @parameter";
          return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql, new { parameter }).AsParallel();
            
        }

        public List<Livro> DeleteLivro(Guid id)
        {
            sql = "DELETE LIVRO WHERE Id = @id ";
            return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql, new { id }).ToList();

        }

        public void Dispose()
        {
            _contexto.Database.Connection.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool EstaAtiva(Domain.Entidades.Livro model)
        {
             sql = $"SELECT Situacao FROM Bibliotecaria WHERE Situacao = 1 and IdBiblioteca ='{model.IdBiblioteca}'  ";
            bool retorno = false;
           
                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql.ToUpper()).AsParallel().Count() > 0)
                    retorno = true;
        
            return retorno;


        }

        public void Excluir(Livro model)
        {
            _contexto.Entry(model).State = EntityState.Deleted;
        }

        public List<Livro> ObterLivro()
        {
               sql = "SELECT Id, Titulo,QtdPg,Editora,Descricao,IdBiblioteca FROM Livro";
             return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).ToList();
                 
           
            
        }

        public List<Livro> ObterLivroPorId(Guid id)
        {
            sql = "SELECT Livro.Id, Livro.Titulo,Livro.QtdPg,Livro.Editora,Livro.Ativo,Livro.Descricao,Livro.Categoria,Livro.IdBiblioteca,Bibliotecaria.RazaoSocial  FROM  Livro INNER JOIN Bibliotecaria ON Bibliotecaria.IdBiblioteca = Livro.IdBiblioteca  WHERE Id = @id";
            return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql, new { id }).ToList();

        }

        public bool TituloUnico(Domain.Entidades.Livro lv)
        {
             sql = $"SELECT * FROM Livro WHERE Titulo = '{lv.Titulo}' ";
            bool retorno = true;
          
                if (_contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).AsParallel() != null && _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).AsParallel().Count() == 0 )
                    retorno = false;
   
            return retorno;
        }

        

        IEnumerable<Bibliotecaria> IRepositorioLivro.DropBiblioteca()
        {
             sql = @"SELECT  Bibliotecaria.IdBiblioteca Id ,Bibliotecaria.RazaoSocial
                            FROM Bibliotecaria
                        INNER JOIN Endereco ON Endereco.IdBlioteca = Bibliotecaria.IdBiblioteca";
           
                 return _contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).ToList();
           
            
        }
    }
}
