using Biblioteca.Core.Domain.Util;
using Dapper;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Biblioteca.Core.Domain.Helper
{
    public class DbHelper:DisposeElement
    {
        public object ExecuteScalar(string sql, DbConnection cn)
        {
            try
            {
                return cn.ExecuteScalar(sql);
            }
            catch (SqlException f)
            {

                throw new Exception(f.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally {
                cn.Close();
            }
         
          
        }  
        
        public void Execute(string sql, DbConnection cn)
        {
            try
            {
                cn.Execute(sql);
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
                cn.Close();
            }
        }


    }
}
