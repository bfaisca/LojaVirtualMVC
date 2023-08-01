using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace LojaNet.DAL
{
    public static class DbHelper
    {
        public static string conexao
        {
            get
            {
                return @"Data Source=DESKTOP-D5VVI9I\SQLEXPRESS;Initial Catalog=LojaNetDb;Integrated Security=True;";
            }
        }
        public static int ExecuteNonQuery(string storedProcedure, params object[] parametros)
        {
            if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ArgumentException("O nome da stored procedure não pode ser nulo ou vazio.", nameof(storedProcedure));
            }

            int retorno = 0;

            using (var cn = new SqlConnection(conexao))
            {
                using (var cmd = new SqlCommand(storedProcedure, cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        PreencherParametros(parametros, cmd);
                        cn.Open();
                        retorno = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Erro ao executar a stored procedure '{storedProcedure}': {ex.Message}", ex);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }

            return retorno;
        }

        public static IDataReader ExecuteReader(string storedProcedure, params object[] parametros)
        {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storedProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            PreencherParametros(parametros, cmd);

            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        private static void PreencherParametros(object[] parametros, SqlCommand cmd)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                }
            }
        }


    }
}
