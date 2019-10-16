using System;
using static System.Console;
using AppBancoDominio;
using AppBancoDLL;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            while (opcao != 4)
            {
                var usuario = new Usuario();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("\n╔═════════════════ MENU DE OPÇÕES ═════════════════╗");
                WriteLine("║                                                  ║");
                WriteLine("║            0 - Cadastrar usuário                 ║");
                WriteLine("║            1 - Editar                            ║");
                WriteLine("║            2 - Excluir                           ║");
                WriteLine("║            3 - Listar                            ║");
                WriteLine("║            4 - Sair                              ║");
                WriteLine("║                                                  ║");
                WriteLine("╚══════════════════════════════════════════════════╝");

                try
                {
                    WriteLine("\nDigite a opção que deseja:");
                    ForegroundColor = ConsoleColor.Red;
                    opcao = int.Parse(ReadLine());

                    switch (opcao)
                    {
                        case 0:
                            Adicionar();
                            break;
                        case 1:
                            Editar();
                            break;
                        case 2:
                            Excluir();
                            break;
                        case 3:
                            SelectUsuarios();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("\nDigite a opção 0, 1, 2, 3 ou 4. Pressione Enter para continuar.");
                            break;
                    }
                    ReadKey();
                    Clear();
                }
                catch (FormatException)
                {
                    WriteLine("Digite um valor numérico inteiro. Pressione Enter para continuar.");
                    ReadKey();
                    Clear();
                }
            }
        }
        
        public static void SelectUsuarios()
        {
            ForegroundColor = ConsoleColor.Blue;
            var leitor = new UsuarioDAO().Listar();
            var usuario = new Usuario();

            foreach (var leitores in leitor)
            {
                WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitores.IdUsu, leitores.NomeUsu, leitores.Cargo, leitores.Data);
            };
        }

        public static void Adicionar()
        {
            var usuario = new Usuario
            {
                IdUsu = 0
            };

            ForegroundColor = ConsoleColor.Blue;
            WriteLine("\nDigite o nome do usuário:");
            ForegroundColor = ConsoleColor.Red;
            usuario.NomeUsu = ReadLine();

            ForegroundColor = ConsoleColor.Blue;
            WriteLine("\nDigite o cargo do usuário:");
            ForegroundColor = ConsoleColor.Red;
            usuario.Cargo = ReadLine();

            DateTime data;

            ForegroundColor = ConsoleColor.Blue;
            WriteLine("\nDigite a data de nascimento do usuário:");
            ForegroundColor = ConsoleColor.Red;
            while (!(DateTime.TryParse(ReadLine(), out data)))
                WriteLine("\nDigite uma data válida.");
            usuario.Data = data;

            new UsuarioDAO().Salvar(usuario);

            SelectUsuarios();
        }

        public static void Editar()
        {
            var usuario = new Usuario();
            var dao = new UsuarioDAO();

            usuario.IdUsu = PedirId();

            var leitor = dao.Listar1(usuario);

            WriteLine("\nVocê tem certeza que deseja editar o seguinte registro?\n\n" +
                "Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor.IdUsu, leitor.NomeUsu, leitor.Cargo, leitor.Data +
                "\n\nPressione Enter para continuar ou Esc para voltar\n");
            if (ReadKey().Key != ConsoleKey.Escape)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("\nDigite o nome do usuário:");
                ForegroundColor = ConsoleColor.Red;
                usuario.NomeUsu = ReadLine();

                ForegroundColor = ConsoleColor.Blue;
                WriteLine("\nDigite o cargo do usuário:");
                ForegroundColor = ConsoleColor.Red;
                usuario.Cargo = ReadLine();

                DateTime data;

                ForegroundColor = ConsoleColor.Blue;
                WriteLine("\nDigite a data de nascimento do usuário:");
                ForegroundColor = ConsoleColor.Red;
                while (!(DateTime.TryParse(ReadLine(), out data)))
                    WriteLine("\nDigite uma data válida.");
                usuario.Data = data;

                dao.Salvar(usuario);
                SelectUsuarios();
            }
        }

        public static void Excluir()
        {
            var usuario = new Usuario();
            var dao = new UsuarioDAO();

            usuario.IdUsu = PedirId();

            var leitor = dao.Listar1(usuario);

            WriteLine("\nVocê tem certeza que deseja excluir o seguinte registro?\n\n" +
                "Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor.IdUsu, leitor.NomeUsu, leitor.Cargo, leitor.Data +
                "\n\nPressione Enter para continuar ou Esc para voltar\n");
            if (ReadKey().Key != ConsoleKey.Escape)
            {
                dao.Excluir(usuario);
                SelectUsuarios();
            }
        }

        private static int idverificado;

        public static int PedirId()
        {
            var usuario = new Usuario();
            var dao = new UsuarioDAO();

            while (!dao.VerificarRegistro(usuario))
            {
                try
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("\nDigite o id. Se o id não existir no banco ele será requisitado novamente.");
                    ForegroundColor = ConsoleColor.Red;
                    idverificado = int.Parse(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("Digite um valor numérico inteiro. Pressione Enter para continuar.");
                    ReadKey();
                }
                usuario.IdUsu = idverificado;
                ForegroundColor = ConsoleColor.Blue;
            }
            return idverificado;
        }
    }
}
