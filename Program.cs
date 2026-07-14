using System;
using InventorySystem.Models;
using InventorySystem.Models.Exceptions;
using InventorySystem.UI;


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

                int escolhaUsuario = ConsoleInput.ValidarEntradaInt("Navegar.", 1, 4);

                if (escolhaUsuario == 1)
                {
                    if (funcionario is Gestor)
                    {
                        Menus.MenuCadastro(ListaDoEstoque);
                    }
                    else
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
                    if (funcionario is Gestor)
                    {
                        Menus.MenuManutencao(ListaDoEstoque);
                    }
                    else
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
    }
}