
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using UsuarioBiblioteca.Domain.Entidades;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioLivro : Biblioteca.Core.Domain.Util.DisposeElement, IRepositorioLivro
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
        }

        

        public IEnumerable<Domain.Entidades.Livro> DadosLivro(string parameter)
        {
             sql = "SELECT Titulo,QtdPg,Editora,Ativo,Descricao,Categoria  FROM Livro INNER JOIN Bibliotecaria ON Bibliotecaria.IdBiblioteca = Livro.IdBiblioteca WHERE Bibliotecaria.Cnpj = @parameter";
            try
            {
                return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql, new { parameter }).AsParallel();
            }
            catch (SqlException f)
            {

                throw new Exception(f.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                _contexto.Database.Connection.Close();
            }

        }

        public bool EstaAtiva(Domain.Entidades.Livro model)
        {
             sql = $"SELECT Situacao FROM Bibliotecaria WHERE Situacao = 1 and IdBiblioteca ='{model.IdBiblioteca}'  ";
            bool retorno = false;
            try
            {
                
                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql.ToUpper()).AsParallel().Count() > 0)
                    retorno = true;
            }
            catch (SqlException f)
            {

                throw new Exception(f.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                _contexto.Database.Connection.Close();
            }
            return retorno;


        }

        public void Excluir(Livro model)
        {
            _contexto.Entry(model).State = EntityState.Deleted;
        }

        public IEnumerable<Livro> ObterLivro()
        {
            sql = $"SELECT * FROM Livro ";
           
            try
            {
                return _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).AsParallel();
                 
            }
            catch (Exception h)
            {

                throw new Exception(h.Message);
            }
            finally
            {
                _contexto.Database.Connection.Close();
            }
            
        }

        public bool TituloUnico(Domain.Entidades.Livro lv)
        {
             sql = $"SELECT * FROM Livro WHERE Titulo = '{lv.Titulo}' ";
            bool retorno = true;
            try
            {
                if (_contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).AsParallel() != null && _contexto.Database.Connection.Query<Domain.Entidades.Livro>(sql).AsParallel().Count() == 0 )
                    retorno = false;
            }
            catch (Exception h)
            {

                throw new Exception(h.Message);
            }
            finally {
                _contexto.Database.Connection.Close();
            }
            return retorno;
        }

        

        IEnumerable<UsuarioBiblioteca.Domain.Entidades.Bibliotecaria> IRepositorioLivro.DropBiblioteca()
        {
             sql = @"SELECT  Bibliotecaria.IdBiblioteca Id ,Bibliotecaria.RazaoSocial
                            FROM Bibliotecaria
                        INNER JOIN Endereco ON Endereco.IdBlioteca = Bibliotecaria.IdBiblioteca";
            try
            {
                 return _contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).ToList();
            }
            catch (SqlException f)
            {

                throw new Exception(f.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                _contexto.Database.Connection.Close();
            }
            
        }
    }
}
