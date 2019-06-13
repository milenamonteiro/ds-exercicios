using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SqlCommand("DELETE FROM TBUsuario WHERE IdUsu = 4", conexao).ExecuteNonQuery();//deletar
            //new SqlCommand("UPDATE TBUsuario SET NomeUsu= 'ME ACHO ESPERTA 3000' WHERE IdUsu = 2", conexao).ExecuteNonQuery();//atualizar
            //new SqlCommand("INSERT INTO TBUsuario (NomeUsu,Cargo,Data) VALUES ('Emma', 'Cerimonialista','04/17/2000')", conexao).ExecuteNonQuery();//inserir
            //regex: ^((0|1)\d{1})/((0|1|2)\d{1})/((19|20)\d{2})
            //string strinsereusu = string.Format("INSERT INTO TBUsuario (NomeUsu,Cargo,Data) VALUES ('{0}','{1}',CONVERT(DATETIME,'{2}',103))", vnome, vcargo, vdata);
            //new SqlCommand(strinsereusu, banco).ExecuteNonQuery();
            //SqlDataReader leitor = new SqlCommand("SELECT * FROM TBUsuario", conexao).ExecuteReader();
            //SqlConnection conexao = new SqlConnection(Properties.Settings.Default.conexao);
            //banco.ExecutaComando(string.Format("INSERT INTO TBUsuario (NomeUsu,Cargo,Data) VALUES ('{0}','{1}',CONVERT(DATETIME,'{2}',103))", vnome, vcargo, vdata));
            
            WriteLine("Digite o nome do usuário");
            string vnome = ReadLine();

            WriteLine("Digite o cargo do usuário");
            string vcargo = ReadLine();

            WriteLine("Digite a data de nascimento do usuário");
            string vdata = ReadLine();

            var banco = new Banco();

            new UsuarioDAO().Insert(vnome, vcargo, vdata);
            
            var leitor = banco.RetornaComando("SELECT * FROM TBUsuario");
            
            while (leitor.Read())
            {
                WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
            }
            ReadLine();
        }
    }
}
