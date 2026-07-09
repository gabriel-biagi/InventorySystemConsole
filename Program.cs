using System;
using InventorySystem.Models;
using InventorySystem.Models.Exceptions;


namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestaoEstoque ListaDoEstoque = new GestaoEstoque();

            GestaoFuncionarios ListaDeFuncionarios = new GestaoFuncionarios();
            ListaDeFuncionarios.AdicionarFuncionario(new Operador("Gabriel", 1000));
            ListaDeFuncionarios.AdicionarFuncionario(new Gestor("Admin", 9999));
            Funcionario funcionario;
            while (true)
            {
                Console.WriteLine("Digite sua matricula");
                int matricula = int.Parse(Console.ReadLine());

                funcionario = ListaDeFuncionarios.RetornaFuncionario(matricula);
                if (funcionario != null)
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("           SISTEMA DE ESTOQUE           ");
                Console.WriteLine("========================================");
                Console.WriteLine("\n [1] Cadastro\n [2] Movimentação\n [3] Manutenção\n [4] Sair");

                int escolhaUsuario = Program.ValidarEntradaInt("Navegar.", 1, 4);

                if (escolhaUsuario == 1)
                {
                    if (funcionario is Gestor)
                    {
                    Menus.MenuCadastro(ListaDoEstoque);
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Você não tem permissão.");
                    }

                }

                if (escolhaUsuario == 2)
                {
                    Menus.MenuMovimentacao(ListaDoEstoque);
                }

                if (escolhaUsuario == 3)
                {
                    if(funcionario is Gestor)
                    {
                    Menus.MenuManutencao(ListaDoEstoque);
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Você não tem permissão.");
                    }
                } 

                if (escolhaUsuario == 4)
                {
                    return;
                }
                
            }
        }







        //metodos
        public static string ValidaString(string local)
        {
            Console.WriteLine($"Digite um nome para o {local}");
            string entrada = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Não pode ficar em branco.");
                entrada = Console.ReadLine();
            }
            return entrada;
        }

        public static int ValidarEntradaInt(string local, int min = 1, int max = int.MaxValue)
        {
            Console.WriteLine($"Digite uma opção para {local}");

            string entrada = Console.ReadLine();

            while (true)
            {
                bool verificaColuna = int.TryParse(entrada, out int saidaInteiro);

                if (verificaColuna && saidaInteiro >= min && saidaInteiro <= max)
                {
                    return saidaInteiro;
                }
                else
                {
                    Console.WriteLine("Erro, Digite uma opção válida.");

                    entrada = Console.ReadLine();
                }
            }
        }

        public static Estoque? BuscaItemPorCodigo(GestaoEstoque gestaoEstoque)
        {
            Console.WriteLine("Digite o código do produto que deseja alterar\nCaso deseja cancelar a busca, digite 0");
            int codigoProduto = Program.ValidarEntradaInt("Código do Produto", 0);
            if (codigoProduto == 0)
            {
                Console.WriteLine("Operação cancelada, voltando ao Menu Inicial");
                return null;
            }
            Estoque item = gestaoEstoque.RetornaItemDoEstoque(codigoProduto);

            while (item == null)
            {
                Console.WriteLine("Não encontrado, caso deseja cancelar a busca, digite 0");
                codigoProduto = Program.ValidarEntradaInt("Código do Produto", 0);
                if (codigoProduto == 0)
                {
                    return null;
                }
                item = gestaoEstoque.RetornaItemDoEstoque(codigoProduto);
            }

            return item;
        }

        public static char ValidaChar(string local)
        {
            Console.WriteLine($"Digite uma opção para {local}");
            string entradaUsuario = Console.ReadLine();
            char entradaUsuarioChar;

            while (string.IsNullOrWhiteSpace(entradaUsuario))
            {
                Console.WriteLine("Não pode estar em branco.");
                entradaUsuario = Console.ReadLine();
            }

            string entradaToLower = entradaUsuario.ToLower();

            while (TentaConverterChar(entradaToLower, out entradaUsuarioChar) || VerificaEntradaChar(entradaUsuarioChar))
            {
                Console.WriteLine("Escolha apenas entre 'S' ou 'N'.");
                entradaUsuario = Console.ReadLine();
                entradaToLower = entradaUsuario.ToLower();
            }

            return entradaUsuarioChar;
        }

        public static bool VerificaEntradaChar(char entradaUser)
        {
            char entradaUserLower = char.ToLower(entradaUser);

            if (entradaUserLower != 'n' && entradaUserLower != 's')
            {
                return false;
            }

            return true;
        }

        public static bool TentaConverterChar(string entradaUsuario, out char saidaUsuario)
        {
            return char.TryParse(entradaUsuario, out saidaUsuario);
        }

    }
}