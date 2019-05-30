using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.conexao);
            //SqlConnection conexao = new SqlConnection(@"Data Source = DESKTOP-UEGTNEB;//conexão via codigo
            //Initial Catalog = DBExemplo;
            //User ID= sa; Password = 1234567;");
            conexao.Open();

           // string strSelecionaUsu = "Select * From TBUsuario";//exibe utilizando a variável
            SqlCommand comando = new SqlCommand("Select * From TBUsuario", conexao);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
            }
          // leitor.Read();
           //Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}",
          //    leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
            Console.WriteLine("Conectado!");
            Console.ReadLine();
        }
    }
}
