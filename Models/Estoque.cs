using System;

namespace InventorySystem.Models
{
    public class Estoque
    {
        public Produto Produto { get; private set; }
        public Locacao Locacao { get; private set; }
        public decimal Quantidade { get; private set; }


        public Estoque(Produto produto, Locacao locacao)
        {
            Produto = produto;
            Locacao = locacao;
            Quantidade = 0;
        }

        public Estoque(Produto produto, Locacao locacao, decimal quantidade)
        {
            Produto = produto;
            Locacao = locacao;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return
                "========================================\n" +
                "              PRODUTO                   \n" +
                "========================================\n" +
                $"Nome       : {Produto.Nome}\n" +
                $"Código     : {Produto.Codigo}\n" +
                $"Quantidade : {Quantidade}\n" +
                "----------------------------------------\n" +
                "              LOCALIZAÇÃO               \n" +
                "----------------------------------------\n" +
                $"Coluna     : {Locacao.Coluna}\n" +
                $"Prateleira : {Locacao.Prateleira}\n" +
                $"Posição    : {Locacao.Item}\n" +
                "========================================";
        }

        public string AdicionaQuantidadeEstoque(decimal quantidade)
        {
            if (quantidade <= 0)
            {
                return "Quantidade inválida!";
            }

            if (Produto.TipoUnidade == TipoUnidade.Un || Produto.TipoUnidade == TipoUnidade.Pct)
            {
                if (!_verificaNumeroInt(quantidade))
                {
                    return "A Quantidade informada não é válida para o tipo de unidade.";
                }

                Quantidade += quantidade;
                return null;
            }

            Quantidade += quantidade;
            return null;
        }

        public string RemoveQuantidadeEstoque(decimal quantidade)
        {
            if (quantidade <= 0)
            {
                return "Quantidade inválida!";
            }

            if (quantidade > Quantidade)
            {
                return "Quantidade informada maior do que disponível em Estoque.";
            }

            if (Produto.TipoUnidade == TipoUnidade.Un || Produto.TipoUnidade == TipoUnidade.Pct)
            {
                if (!_verificaNumeroInt(quantidade))
                {
                    return "A Quantidade informada não é válida para o tipo de unidade.";
                }

                Quantidade -= quantidade;
                return null;
            }

            Quantidade -= quantidade;
            return null;
        }

        private bool _verificaNumeroInt(decimal quantidade)
        {
            return quantidade % 1 == 0;
        }
    }
}