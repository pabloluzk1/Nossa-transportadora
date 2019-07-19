using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MampTransporte;


namespace Repositorio
{
    public class Conexao
    {
        public string CadeiaConexao = @"";




        public static SqlCommand Conectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConfigurationManager.
                ConnectionStrings["DefaultConnection"]
                .ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;

            return comando;
        }
    }
}