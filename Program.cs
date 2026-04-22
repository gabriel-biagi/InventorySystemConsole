using System;
using InventorySystem.Models;


namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool escolhaInicial = true;
            while (escolhaInicial)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("           SISTEMA DE ESTOQUE           ");
                Console.WriteLine("========================================");
                Console.WriteLine("Deseja criar um produto? (S/N)");
                string escolhaCriarProd = Console.ReadLine();
                char escolhaFinalChar;
                bool verificaEscolhaProd = char.TryParse(escolhaCriarProd, out escolhaFinalChar);

                while (!verificaEscolhaProd)
                {
                    Console.WriteLine("Digite apenas um caracter");
                    escolhaCriarProd = Console.ReadLine();
                    verificaEscolhaProd = char.TryParse(escolhaCriarProd, out escolhaFinalChar);
                }

                while (escolhaFinalChar != 'S' && escolhaFinalChar != 's' && escolhaFinalChar != 'N' && escolhaFinalChar != 'n')
                {
                    Console.WriteLine("Escolha inválida!");
                    escolhaCriarProd = Console.ReadLine();
                    verificaEscolhaProd = char.TryParse(escolhaCriarProd, out escolhaFinalChar);
                }

                while (escolhaFinalChar == 'N' || escolhaFinalChar == 'n')
                {
                    Console.WriteLine("Saindo...");
                    escolhaInicial = false;
                    return;
                }

                Console.WriteLine("\n--- CADASTRO DE PRODUTO ---");
                Console.WriteLine("Nome do produto:");
                string entradaNomeProduto= Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entradaNomeProduto)) {
                    Console.WriteLine("Nome inválido. Tente novamente.");
                    entradaNomeProduto = Console.ReadLine();
                }


                Console.WriteLine("Digite o código");
                string entradaCodigoProduto = Console.ReadLine();
                int codigoProduto;
                bool verificaCodProd = int.TryParse(entradaCodigoProduto, out codigoProduto);
                while (!verificaCodProd)
                {
                    Console.WriteLine("Código Inválido. Digite um número inteiro.");
                    entradaCodigoProduto = Console.ReadLine();
                    verificaCodProd = int.TryParse(entradaCodigoProduto, out codigoProduto);
                }

                Console.WriteLine("\nTipo de unidade:");
                Console.WriteLine("\n [1] Unidade\n [2] Pacote\n [3] Kilograma\n [4] Litro");
                Console.Write("Escolha uma opção: ");
                string entradaTipoUnidade = Console.ReadLine();
                int tipoUnidade;
                bool verificaTipoUn = int.TryParse(entradaTipoUnidade, out tipoUnidade);
                while (!verificaTipoUn)
                {
                    Console.WriteLine("Opção inválida. Escolha entre 1 e 4.");
                    Console.WriteLine("Digite o tipo de unidade:\n [1] Unidade\n [2] Pacote\n [3] Kilograma\n [4] Litro");
                    entradaTipoUnidade = Console.ReadLine();
                    verificaTipoUn = int.TryParse(entradaTipoUnidade, out tipoUnidade);
                }

                Produto produto = null;

                switch (tipoUnidade)
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
                Console.WriteLine("Coluna:");
                int escolhaColuna;
                string entradaColuna = Console.ReadLine();
                bool verificaColuna = int.TryParse(entradaColuna, out escolhaColuna);
                while (!verificaColuna)
                {
                    Console.WriteLine("Valor Inválido. Digite um número inteiro.");
                    entradaColuna = Console.ReadLine();
                    verificaColuna = int.TryParse(entradaColuna, out escolhaColuna);
                }

                Console.WriteLine("Prateleira:");
                int escolhaPrateleira;
                string entradaPrateleira = Console.ReadLine();
                bool verificaPrateleira = int.TryParse(entradaPrateleira, out escolhaPrateleira);
                while (!verificaPrateleira)
                {
                    Console.WriteLine("Valor Inválido. Digite um número inteiro.");
                    entradaPrateleira = Console.ReadLine();
                    verificaPrateleira = int.TryParse(entradaPrateleira, out escolhaPrateleira);
                }

                Console.WriteLine("Posição:");
                int escolhaPosicao;
                string entradaPosicao = Console.ReadLine();
                bool verificaPosicao = int.TryParse(entradaPosicao, out escolhaPosicao);
                while (!verificaPosicao)
                {
                    Console.WriteLine("Valor Inválido. Digite um número inteiro.");
                    entradaPosicao = Console.ReadLine();
                    verificaPosicao = int.TryParse(entradaPosicao, out escolhaPosicao);
                }

                Locacao locacao = new Locacao(escolhaColuna, escolhaPrateleira, escolhaPosicao);

                Console.WriteLine("\nQuantidade Inicial");
                int escolhaQuantidade;
                string entradaQuantidade = Console.ReadLine();
                bool verificaQuantidade = int.TryParse(entradaQuantidade, out escolhaQuantidade);
                while (!verificaQuantidade || escolhaQuantidade <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Deve ser maior que zero.");
                    entradaQuantidade = Console.ReadLine();
                    verificaQuantidade = int.TryParse(entradaQuantidade, out escolhaQuantidade);
                }

                Estoque estoque = new Estoque(produto, locacao, escolhaQuantidade);

                Console.WriteLine(estoque);

                Console.WriteLine("\n--- AÇÕES ---");
                Console.WriteLine("\n [1] Adicionar\n [2] Remover\n [3] Sair");
                int escolhaAcao;
                string entradaAcao = Console.ReadLine();
                bool verificaAcao = int.TryParse(entradaAcao, out escolhaAcao);
                while (!verificaAcao)
                {
                    Console.WriteLine("Digite o Número correspondente...\n");
                    Console.WriteLine("\n [1] Adicionar\n [2] Remover\n [3] Sair");
                    entradaAcao = Console.ReadLine();
                    verificaAcao = int.TryParse(entradaAcao, out escolhaAcao);
                }

                while (escolhaAcao != 1 && escolhaAcao != 2 && escolhaAcao != 3)
                {
                    Console.WriteLine("Digite o Número correspondente...\n");
                    Console.WriteLine("\n [1] Adicionar\n [2] Remover\n [3] Sair");
                    entradaAcao = Console.ReadLine();
                    verificaAcao = int.TryParse(entradaAcao, out escolhaAcao);
                }

                if (escolhaAcao == 1)
                {
                    Console.Write("Digite a quantidade: ");
                    string entradaQtd = Console.ReadLine();
                    decimal escolhaQtd;
                    bool verificaQtd = decimal.TryParse(entradaQtd, out escolhaQtd);
                        while (!verificaQtd)
                    {
                        Console.WriteLine("Valor inválido.");
                        Console.Write("\nDigite a quantidade: ");
                        entradaQtd = Console.ReadLine();
                        verificaQtd = decimal.TryParse(entradaQtd, out escolhaQtd);
                    }

                    string retornoMetodo = estoque.AdicionaQuantidadeEstoque(escolhaQtd);
                    if (retornoMetodo == null)
                    {
                        Console.WriteLine("Operação realizada com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine(retornoMetodo);
                        Console.WriteLine("\nEncerrando sistema...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine(estoque);

                }

                if (escolhaAcao == 2)
                {
                    Console.Write("Digite a quantidade: ");
                    string entradaQtdSair = Console.ReadLine();
                    decimal escolhaQtdSair;
                    bool verificaQtdSair = decimal.TryParse(entradaQtdSair, out escolhaQtdSair);
                    while (!verificaQtdSair)
                    {
                        Console.WriteLine("Valor inválido.");
                        Console.Write("\nDigite a quantidade: ");
                        entradaQtdSair = Console.ReadLine();
                        verificaQtdSair = decimal.TryParse(entradaQtdSair, out escolhaQtdSair);
                    }

                    string retornoMetodo = estoque.RemoveQuantidadeEstoque(escolhaQtdSair);
                    if (retornoMetodo == null)
                    {
                        Console.WriteLine("Operação realizada com sucesso.");
                    } else
                    {
                        Console.WriteLine(retornoMetodo);
                        Console.WriteLine("\nEncerrando sistema...");
                        Console.ReadKey();
                        break;
                    }
                        

                    Console.WriteLine(estoque);
                }

                if (escolhaAcao == 3)
                {
                    Console.WriteLine("Saindo...");
                    escolhaInicial = false;
                    return;
                }

                Console.ReadKey();
            }
        }
    }
}