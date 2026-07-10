using InventorySystem.Models.Exceptions;
using System;

namespace InventorySystem.Models
{
    public class Menus
    {
        public static void MenuManutencao(GestaoEstoque ListaDoEstoque)
        {
            Console.WriteLine("\n--- Menu de Manutenção ---");
            Console.WriteLine("\n--- AÇÕES ---");
            Console.WriteLine("\n [1] Alterar Nome de Produto\n [2] Remover Produto do Estoque\n [3] Sair");

            int escolhaAcao = ConsoleInput.ValidarEntradaInt("Ação Desejada", 1, 3);

            if (escolhaAcao == 3)
            {
                return;
            }

            if (escolhaAcao == 1)
            {
                while (true)
                {
                    Estoque item = ConsoleInput.BuscaItemPorCodigo(ListaDoEstoque);

                    if (item == null)
                    {
                        return;
                    }

                    string novoNome = ConsoleInput.ValidaString("Produto");
                    item.Produto.AlterarNome(novoNome);
                    Console.WriteLine("Processo concluido, nome atualizado.");
                    return;
                }
            }

            if (escolhaAcao == 2)
            {
                Estoque item = ConsoleInput.BuscaItemPorCodigo(ListaDoEstoque);

                if (item == null)
                {
                    return;
                }

                ListaDoEstoque.RemoverDoEstoque(item);
            }
        }

        public static void MenuCadastro(GestaoEstoque ListaDoEstoque)
        {

            while (true)
            {
                try
                {


                    Console.WriteLine("\n--- CADASTRO DE PRODUTO ---");
                    string entradaNomeProduto = ConsoleInput.ValidaString("Produto");
                    int codigoProduto = ConsoleInput.ValidarEntradaInt("Código do Produto");

                    Console.WriteLine("\nTipo de unidade:");
                    Console.WriteLine("\n [1] Unidade\n [2] Pacote\n [3] Kilograma\n [4] Litro");
                    Console.Write("Escolha uma opção: ");
                    int entradaTipoUnidade = ConsoleInput.ValidarEntradaInt("Tipo de Unidade", 1, 4);

                    TipoUnidade tipoUnidade = entradaTipoUnidade switch
                    {
                        1 => TipoUnidade.Un,
                        2 => TipoUnidade.Pct,
                        3 => TipoUnidade.Kg,
                        4 => TipoUnidade.Lt,
                    };

                    Produto produto = new Produto(entradaNomeProduto, codigoProduto, tipoUnidade);

                    Console.WriteLine("\n--- LOCALIZAÇÃO ---");
                    int escolhaColuna = ConsoleInput.ValidarEntradaInt("Coluna");
                    int escolhaPrateleira = ConsoleInput.ValidarEntradaInt("Prateleira");
                    int escolhaPosicao = ConsoleInput.ValidarEntradaInt("Posição");
                    Locacao locacao = new Locacao(escolhaColuna, escolhaPrateleira, escolhaPosicao);

                    Console.WriteLine("\nQuantidade Inicial");
                    int escolhaQuantidade = ConsoleInput.ValidarEntradaInt("Quantidade");

                    Estoque estoque = new Estoque(produto, locacao, escolhaQuantidade);
                    ListaDoEstoque.AdicionarAoEstoque(estoque);

                    Console.WriteLine(estoque.ToDetalhadoString());

                    Console.WriteLine("Deseja Continuar? s/n");
                    char escolha = ConsoleInput.ValidaChar("ação");

                    if (escolha == 'n')
                    {
                        return;
                    }
                }
                catch (EstoqueException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
        }

        public static void MenuMovimentacao(GestaoEstoque ListaDoEstoque)
        {
            Console.WriteLine("\n--- Menu de Movimentação ---");
            Console.WriteLine("\n--- AÇÕES ---");
            Console.WriteLine("\n [1] Adicionar Quantidade\n [2] Remover Quantidade\n [3] Listar Estoque\n [4] Sair");

            int escolhaAcao = ConsoleInput.ValidarEntradaInt("Ação Desejada", 1, 4);
            if (escolhaAcao == 1)
            {
                while (true)
                {

                    try
                    {
                        Estoque item = ConsoleInput.BuscaItemPorCodigo(ListaDoEstoque);

                        if (item == null)
                        {
                            return;
                        }

                        Console.WriteLine("Digite a quantidade para remover, digite 0 caso não deseja alterar");
                        int qtdRemover = ConsoleInput.ValidarEntradaInt("Quantidade para remover", 0);

                        if (qtdRemover == 0)
                        {
                            return;
                        }

                        item.AdicionaQuantidadeEstoque(qtdRemover);
                    }
                    catch (EstoqueException e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                    }
                }
            }
            if (escolhaAcao == 2)
            {
                while (true)
                {
                    try
                    {

                        Estoque item = ConsoleInput.BuscaItemPorCodigo(ListaDoEstoque);

                        if (item == null)
                        {
                            return;
                        }

                        Console.WriteLine("Digite a quantidade para remover, digite 0 caso não deseja alterar");
                        int qtdRemover = ConsoleInput.ValidarEntradaInt("Quantidade para remover", 0);

                        if (qtdRemover == 0)
                        {
                            return;
                        }

                        item.RemoveQuantidadeEstoque(qtdRemover);
                    }
                    catch (EstoqueException e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                    }
                }

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
                return;
            }


        }



        //Métodos Privados
        
    }
    }

