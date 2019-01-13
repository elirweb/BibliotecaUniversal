using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using Dapper;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioBibliotecaria: Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria
    {
      
        private readonly Contexto.Contexto _contexto;
        private  string sql = string.Empty;
        public RepositorioBibliotecaria(Contexto.Contexto cont) { 
            _contexto = cont;
          
        }
        
        public void Adicionar(Domain.Entidades.Bibliotecaria bibliotecaria)
        {

            _contexto.Bibliotecaria.Add(bibliotecaria);
        }

        public void Atualizar(Bibliotecaria bi)
        {
            _contexto.Entry(bi).State = EntityState.Modified;
        }

        public bool Authenticar(Bibliotecaria bi)
        {
             sql = $"SELECT Usuario,Senha FROM Bibliotecaria WHERE Usuario = '{bi.Usuario}'  and  Senha = '{bi.Senha}'";
            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).AsParallel().Count() > 0)
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

        public bool CNPJUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
             sql = $"SELECT Cnpj FROM Bibliotecaria WHERE Cnpj = '{bibliotecaria.Cnpj._cnpj}' ";

            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).AsParallel().Count() > 0)
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

        public void Dispose()
        {
            _contexto.Database.Connection?.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool EmailUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
             sql = $"SELECT Email FROM Bibliotecaria WHERE Email = '{bibliotecaria.Email.Endereco}' ";
            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).AsParallel().Count() > 0)
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

      

        public bool LoginUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
             sql = $"SELECT Usuario FROM Bibliotecaria WHERE Usuario = '{bibliotecaria.Usuario}' ";
            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Bibliotecaria>(sql).AsParallel().Count() > 0)
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
    }
}
