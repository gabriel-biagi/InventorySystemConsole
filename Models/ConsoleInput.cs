using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class ConsoleInput
    {
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
            int codigoProduto = ConsoleInput.ValidarEntradaInt("Código do Produto", 0);
            if (codigoProduto == 0)
            {
                Console.WriteLine("Operação cancelada, voltando ao Menu Inicial");
                return null;
            }
            Estoque item = gestaoEstoque.RetornaItemDoEstoque(codigoProduto);

            while (item == null)
            {
                Console.WriteLine("Não encontrado, caso deseja cancelar a busca, digite 0");
                codigoProduto = ConsoleInput.ValidarEntradaInt("Código do Produto", 0);
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

            while (ConsoleInput.TentaConverterChar(entradaToLower, out entradaUsuarioChar) || ConsoleInput.VerificaEntradaChar(entradaUsuarioChar))
            {
                Console.WriteLine("Escolha apenas entre 'S' ou 'N'.");
                entradaUsuario = Console.ReadLine();
                entradaToLower = entradaUsuario.ToLower();
            }

            return entradaUsuarioChar;
        }

        public static bool TentaConverterChar(string entradaUsuario, out char saidaUsuario)
        {
            return char.TryParse(entradaUsuario, out saidaUsuario);
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
    }
}
