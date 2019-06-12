using System;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleBanco1
{
    class Banco : IDisposable
    {
        private readonly SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(@"Data Source=DESKTOP-UEGTNEB;Initial Catalog=DBExemplo;Persist Security Info=True;User ID=sa;Password=1234567");
            conexao.Open();
        }

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
        }

        public SqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new SqlCommand(StrQuery, conexao);
            return comando.ExecuteReader();
        }
        
        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}