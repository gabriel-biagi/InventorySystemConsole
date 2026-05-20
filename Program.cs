using System;
using InventorySystem.Models;
using System.Globalization;
using System.Collections.Generic;


namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestaoEstoque ListaDoEstoque = new GestaoEstoque();
            bool escolhaInicial = true;
            while (escolhaInicial)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("           SISTEMA DE ESTOQUE           ");
                Console.WriteLine("========================================");
                Console.WriteLine("Deseja criar um produto? (S/N)");
                string entradaUsuario = Console.ReadLine();
                char entradaUsuarioChar;

                while (!_tentaConverterChar(entradaUsuario, out entradaUsuarioChar) || !_verificaEntradaInicial(entradaUsuarioChar))
                {
                    Console.WriteLine("Escolha apenas entre 'S' ou 'N'.");
                    entradaUsuario = Console.ReadLine();
                }

                if (!_liberarAcessoInicial(entradaUsuarioChar))
                {
                    Console.WriteLine("O Programa irá fechar! Pressione qualquer tecla...");
                    Console.ReadKey();
                    escolhaInicial = false;
                    return;
                }

                Console.WriteLine("\n--- CADASTRO DE PRODUTO ---");
                Console.WriteLine("Nome do produto:");
                string entradaNomeProduto = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entradaNomeProduto))
                {
                    Console.WriteLine("Nome inválido. Tente novamente.");
                    entradaNomeProduto = Console.ReadLine();
                }


                Console.WriteLine("CÓDIGO");
                int codigoProduto = _validarEntradaInt("Código do Produto");

                Console.WriteLine("\nTipo de unidade:");
                Console.WriteLine("\n [1] Unidade\n [2] Pacote\n [3] Kilograma\n [4] Litro");
                Console.Write("Escolha uma opção: ");
                int entradaTipoUnidade = _validarEntradaInt("Tipo de Unidade", 1, 4);

                Produto produto = null;

                switch (entradaTipoUnidade)
                {
                    case 1:
                        produto = new Produto(entradaNomeProduto, codigoProduto, TipoUnidade.Un);
                        break;
                    case 2:
                        produto = new Produto(entradaNomeProduto, codigoProduto, TipoUnidade.Pct);
                        break;
                    case 3:
                        produto = new Produto(entradaNomeProduto, codigoProduto, TipoUnidade.Kg);
                        break;
                    case 4:
                        produto = new Produto(entradaNomeProduto, codigoProduto, TipoUnidade.Lt);
                        break;
                }

                Console.WriteLine("\n--- LOCALIZAÇÃO ---");
                int escolhaColuna = _validarEntradaInt("Coluna");

                int escolhaPrateleira = _validarEntradaInt("Prateleira");

                int escolhaPosicao = _validarEntradaInt("Posição");

                Locacao locacao = new Locacao(escolhaColuna, escolhaPrateleira, escolhaPosicao);

                Console.WriteLine("\nQuantidade Inicial");
                int escolhaQuantidade = _validarEntradaInt("Quantidade");

                Estoque estoque = new Estoque(produto, locacao, escolhaQuantidade);
                ListaDoEstoque.AdicionarAoEstoque(estoque);

                Console.WriteLine(estoque.ToDetalhadoString());

                Console.WriteLine("\n--- AÇÕES ---");
                Console.WriteLine("\n [1] Adicionar Quantidade\n [2] Remover Quantidade\n [3] Listar Estoque\n [4] Remover Item do Estoque\n [5] Sair");
                int escolhaAcao = _validarEntradaInt("Ação Desejada", 1, 5);

                if (escolhaAcao == 1)
                {
                    int escolhaQtd;
                    string retornoMetodo;
                    do
                    {
                        escolhaQtd = _validarEntradaInt("Quantidade");
                        retornoMetodo = estoque.AdicionaQuantidadeEstoque(escolhaQtd);
                        if (retornoMetodo == null)
                        {
                            Console.WriteLine("Operação bem sucedida.");
                        }
                        else
                        {
                            Console.WriteLine(retornoMetodo);
                        }
                    } while (retornoMetodo != null);

                    Console.WriteLine(estoque.ToDetalhadoString());

                }

                if (escolhaAcao == 2)
                {
                    int escolhaQtdSair;
                    string retornoMetodo;
                    do
                    {
                        escolhaQtdSair = _validarEntradaInt("Quantidade");
                        retornoMetodo = estoque.RemoveQuantidadeEstoque(escolhaQtdSair);
                        if (retornoMetodo == null)
                        {
                            Console.WriteLine("Operação bem sucedida.");
                        }
                        else
                        {
                            Console.WriteLine(retornoMetodo);
                        }
                    } while (retornoMetodo != null);


                    Console.WriteLine(estoque.ToDetalhadoString());
                }

                if (escolhaAcao == 3)
                {
                    foreach (Estoque item in ListaDoEstoque.ItensEstoque)
                    {
                        Console.WriteLine(item);
                    }
                }

                if (escolhaAcao == 4)
                {

                    int entradaCodigoProduto = _validarEntradaInt("Código do Produto");
                    string retornoMetodo = ListaDoEstoque.RemoverDoEstoque(entradaCodigoProduto);
                    if (retornoMetodo == null)
                    {
                        Console.WriteLine("Operação bem sucedida.");
                    } else
                    {
                        Console.WriteLine(entradaCodigoProduto);
                    }
                }

                if (escolhaAcao == 5)
                {
                    Console.WriteLine("Saindo...");
                    escolhaInicial = false;
                    return;
                }

                Console.ReadKey();
            }
        }

        private static bool _verificaEntradaInicial(char entradaUser)
        {
            char entradaUserLower = char.ToLower(entradaUser);

            if (entradaUserLower != 'n' && entradaUserLower != 's')
            {
                return false;
            }

            return true;
        }

        private static bool _liberarAcessoInicial(char entradaUser)
        {
            char entradaUserLower = char.ToLower(entradaUser);

            return entradaUserLower == 's';
        }

        private static bool _ehChar(char entradaUsuario)
        {
            bool ehChar = Char.IsLetter(entradaUsuario);
            return ehChar;
        }

        private static bool _tentaConverterChar(string entradaUsuario, out char saidaUsuario)
        {
            return char.TryParse(entradaUsuario, out saidaUsuario);
        }

        private static int _validarEntradaInt(string local, int min = 1, int max = int.MaxValue)
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

    }
}