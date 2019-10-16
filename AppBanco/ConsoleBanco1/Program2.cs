using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario();
            int option = 1;

            do
            {
                SelectUsuarios();

                WriteLine("\nDigite 1 para atualizar/adicionar e 2 para excluir, 3 para sair");
                option = Convert.ToInt16(ReadLine());

                switch (option)
                {
                    case 1:
                        AddInsert();
                        break;
                    case 2:
                        Excluir();
                        break;
                    case 3:
                        ReadKey();
                        break;
                    default:
                        break;
                }

                Clear();

            } while (option != 3);
        }

        public static void SelectUsuarios()
        {
            var leitor = new UsuarioDAO().Listar();
            var usuario = new Usuario();

            foreach(var leitores in leitor)
            {
                WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitores.IdUsu, leitores.NomeUsu, leitores.Cargo, leitores.Data);
            };
        }
        
        public static void AddInsert()
        {
            var usuario = new Usuario();

            WriteLine("\nDigite o id 0 para inserir ou um existente para atualizar:");
            usuario.IdUsu = Convert.ToInt16(ReadLine());

            WriteLine("\nDigite o nome do usuário:");
            usuario.NomeUsu = ReadLine();

            WriteLine("\nDigite o cargo do usuário:");
            usuario.Cargo = ReadLine();

            WriteLine("\nDigite a data de nascimento do usuário:");
            usuario.Data = Convert.ToDateTime(ReadLine()); 

            new UsuarioDAO().Salvar(usuario);
        }

        public static void Excluir()
        {
            var usuario = new Usuario();

            WriteLine("\nDigite o id");
            usuario.IdUsu = Convert.ToInt16(ReadLine());

            new UsuarioDAO().Excluir(usuario);
        }
    }
}
