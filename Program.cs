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
            while (true)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("           SISTEMA DE ESTOQUE           ");
                Console.WriteLine("========================================");
                Console.WriteLine("\n [1] Cadastro\n [2] Movimentação\n [3] Manutenção\n [4] Sair");

                int escolhaUsuario = validarEntradaInt("Navegar.", 1, 4);

                if (escolhaUsuario == 1)
                {
                    menuCadastro(ListaDoEstoque);
                }
                if (escolhaUsuario == 2)
                {
                    menuMovimentacao(ListaDoEstoque);
                }
                if (escolhaUsuario == 3)
                {
                    menuManutencao(ListaDoEstoque);
                }
                if (escolhaUsuario == 4)
                {
                    return;
                }
                
            }
        }

        private static bool verificaEntradaChar(char entradaUser)
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

        private static char validaChar(string local)
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

            while (!_tentaConverterChar(entradaToLower, out entradaUsuarioChar) || !verificaEntradaChar(entradaUsuarioChar))
            {
                Console.WriteLine("Escolha apenas entre 'S' ou 'N'.");
                entradaUsuario = Console.ReadLine();
                entradaToLower = entradaUsuario.ToLower();
            }

            return entradaUsuarioChar;
        }

        private static string validaString(string local)
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

        private static int validarEntradaInt(string local, int min = 1, int max = int.MaxValue)
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

        private static Estoque? buscaItemPorCodigo(GestaoEstoque gestaoEstoque)
        {
            Console.WriteLine("Digite o código do produto que deseja alterar\nCaso deseja cancelar a busca, digite 0");
            int codigoProduto = validarEntradaInt("Código do Produto", 0);
            if (codigoProduto == 0)
            {
                Console.WriteLine("Operação cancelada, voltando ao Menu Inicial");
                return null;
            }
            Estoque item = gestaoEstoque.retornaItemDoEstoque(codigoProduto);

            while (item == null)
            {
                Console.WriteLine("Não encontrado, caso deseja cancelar a busca, digite 0");
                codigoProduto = validarEntradaInt("Código do Produto", 0);
                if (codigoProduto == 0)
                {
                    return null;
                }
                item = gestaoEstoque.retornaItemDoEstoque(codigoProduto);
            }

            return item;
        }

        //MENUS

        private static void menuCadastro(GestaoEstoque ListaDoEstoque)
        {

            while (true)
            {
                Console.WriteLine("\n--- CADASTRO DE PRODUTO ---");
                string entradaNomeProduto = validaString("Produto");
                int codigoProduto = validarEntradaInt("Código do Produto");

                Console.WriteLine("\nTipo de unidade:");
                Console.WriteLine("\n [1] Unidade\n [2] Pacote\n [3] Kilograma\n [4] Litro");
                Console.Write("Escolha uma opção: ");
                int entradaTipoUnidade = validarEntradaInt("Tipo de Unidade", 1, 4);

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
                int escolhaColuna = validarEntradaInt("Coluna");
                int escolhaPrateleira = validarEntradaInt("Prateleira");
                int escolhaPosicao = validarEntradaInt("Posição");
                Locacao locacao = new Locacao(escolhaColuna, escolhaPrateleira, escolhaPosicao);

                Console.WriteLine("\nQuantidade Inicial");
                int escolhaQuantidade = validarEntradaInt("Quantidade");

                Estoque estoque = new Estoque(produto, locacao, escolhaQuantidade);
                ListaDoEstoque.AdicionarAoEstoque(estoque);

                Console.WriteLine(estoque.ToDetalhadoString());

                Console.WriteLine("Deseja Continuar? s/n");
                char escolha = validaChar("ação");

                if (escolha == 'n')
                {
                    return;
                }

            }
        }

        private static void menuMovimentacao(GestaoEstoque ListaDoEstoque)
        {
            Console.WriteLine("\n--- Menu de Movimentação ---");
            Console.WriteLine("\n--- AÇÕES ---");
            Console.WriteLine("\n [1] Adicionar Quantidade\n [2] Remover Quantidade\n [3] Listar Estoque\n [4] Sair");

            int escolhaAcao = validarEntradaInt("Ação Desejada", 1, 4);
            if (escolhaAcao == 1)
            {
                while (true)
                {
                    Estoque item = buscaItemPorCodigo(ListaDoEstoque);

                    if (item == null)
                    {
                        return;
                    }

                    Console.WriteLine("Digite a quantidade para remover, digite 0 caso não deseja alterar");
                    int qtdRemover = validarEntradaInt("Quantidade para remover", 0);

                    if (qtdRemover == 0)
                    {
                        return;
                    }

                    string retornoMetodo = item.AdicionaQuantidadeEstoque(qtdRemover);
                    while (retornoMetodo != null)
                    {
                        Console.WriteLine(retornoMetodo);
                        qtdRemover = validarEntradaInt("Quantidade para remover", 0);
                        retornoMetodo = item.AdicionaQuantidadeEstoque(qtdRemover);
                    }
                }
            }
            if (escolhaAcao == 2)
            {
                while (true)
                {
                    Estoque item = buscaItemPorCodigo(ListaDoEstoque);

                    if (item == null)
                    {
                        return;
                    }

                    Console.WriteLine("Digite a quantidade para remover, digite 0 caso não deseja alterar");
                    int qtdRemover = validarEntradaInt("Quantidade para remover", 0);

                    if (qtdRemover == 0)
                    {
                        return;
                    }

                    string retornoMetodo = item.RemoveQuantidadeEstoque(qtdRemover);
                    while (retornoMetodo != null)
                    {
                        Console.WriteLine(retornoMetodo);
                        qtdRemover = validarEntradaInt("Quantidade para remover", 0);
                        retornoMetodo = item.RemoveQuantidadeEstoque(qtdRemover);
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

        private static void menuManutencao(GestaoEstoque ListaDoEstoque)
        {
            Console.WriteLine("\n--- Menu de Manutenção ---");
            Console.WriteLine("\n--- AÇÕES ---");
            Console.WriteLine("\n [1] Alterar Nome de Produto\n [2] Remover Produto do Estoque\n [3] Sair");

            int escolhaAcao = validarEntradaInt("Ação Desejada", 1, 3);

            if (escolhaAcao == 3)
            {
                return;
            }

            if (escolhaAcao == 1)
            {
                while (true)
                {
                    Estoque item = buscaItemPorCodigo(ListaDoEstoque);

                    if (item == null)
                    {
                        return;
                    }

                    string novoNome = validaString("Produto");
                    item.Produto.AlterarNome(novoNome);
                    Console.WriteLine("Processo concluido, nome atualizado.");
                    return;
                }
            }

            if (escolhaAcao == 2)
            {
                Estoque item = buscaItemPorCodigo(ListaDoEstoque);

                if (item == null)
                {
                    return;
                }

                ListaDoEstoque.RemoverDoEstoque(item);
            }

        }
    }
}