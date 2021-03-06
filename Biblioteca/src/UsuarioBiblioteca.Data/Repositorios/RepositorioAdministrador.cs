﻿
using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioAdministrador : Domain.Interfaces.IRepositorios.IRepositorioAdministrador
    {
        private readonly Contexto.Contexto _contexto;
        private string sql = string.Empty;
        public RepositorioAdministrador(Contexto.Contexto coc)
        {
            _contexto = coc;
            
        }
        public void Adicionar(Domain.Entidades.Administradores ad)
        {
            _contexto.Administradores.Add(ad);
        }

        public bool Authenticar(Administradores model)
        {
            DynamicParameters p = new DynamicParameters();
             sql = "SELECT Login,Senha FROM Administradores WHERE Login=login and Senha=senha";
            p.Add("login", model.Login);
            p.Add("senha", model.Senha.CodigoSenha);

            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Administradores>(sql,new {p}).ToList().Count() > 0)
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

        public bool LoginUnico(Domain.Entidades.Administradores model)
        {
             sql  = $"SELECT Login FROM Administradores WHERE Login = '{model.Login}' ";
            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidades.Administradores>(sql).AsParallel().Count() > 0)
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
