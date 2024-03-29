﻿

using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Usuario.Data.Repositorio
{
    public class RepositorioUsuario : Domain.Interfaces.Repositorios.IRepositorioUsuario
    {
        private readonly Contexto.Contexto _contexto;
        private string sql = string.Empty;
        public RepositorioUsuario(Contexto.Contexto coc)
        {
            _contexto = coc;
            
        }
        public void Adicionar(Domain.Entidade.Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
           
        }

        public bool AlteracaoSenha(string email,string senha)
        {
          
            sql = $"SELECT Senha FROM Usuario WHERE Email = '{email}'  ";
            DynamicParameters p = new DynamicParameters();
            p.Add("email", email);
            p.Add("senha", senha);

            bool retorno = false;
            try
            {

                if (_contexto.Database.Connection.Query<Domain.Entidade.Usuario>(sql,new {p}).AsParallel().Count() > 0)
                {
                    var senha_nova = new Biblioteca.Core.Domain.ValueObjects.Senha(senha);
                    sql =  $"UPDATE USUARIO SET Senha= '{senha_nova.CodigoSenha}' WHERE Email = '{email}' ";
                    retorno = true;
                }
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
                _contexto.Database.Connection.Dispose();
            }
            return retorno;


           
        }

        public bool Authenticar(Domain.Entidade.Usuario usuario)
        {

           
            sql = "SELECT Login FROM Usuario WHERE Login=login";
            DynamicParameters p = new DynamicParameters();
            p.Add("login", usuario.Login);
            //p.Add("senha",usuario.Senha.CodigoSenha);



            bool retorno = false;
         

                if (_contexto.Database.Connection.Query<Domain.Entidade.Usuario>(sql,new {p}).ToList().Count() > 0)
                    retorno = true;
         
            return retorno;
        }

        public bool cpfunico(Domain.Entidade.Usuario usuario)
        {
            
            sql = $"SELECT Cpf FROM Usuario WHERE Cpf = '{usuario.Cpf.Codigo}' ";
            bool retorno = false;
        

                if (_contexto.Database.Connection.Query<Domain.Entidade.Usuario>(sql).AsParallel().Count() > 0)
                    retorno = true;
        
            return retorno;
        }

        public void Dispose()
        {
            _contexto.Database.Connection?.Dispose();
        }

        public bool loginunico(Domain.Entidade.Usuario usuario)
        {
           
            sql = $"SELECT Login FROM Usuario WHERE Login = '{usuario.Login}' ";
            bool retorno = false;
         

                if (_contexto.Database.Connection.Query<Domain.Entidade.Usuario>(sql).AsParallel().Count() > 0)
                    retorno = true;
         
            return retorno;
        }

        public bool RecuperarSenha(string email)
        {
           
           sql = $"SELECT Email FROM Usuario WHERE Email = '{email}' ";
            bool retorno = false;
           

                if (_contexto.Database.Connection.Query<Domain.Entidade.Usuario>(sql).AsParallel().Count() > 0)
                    retorno = true;
           
            return retorno;

        }
    }
}
