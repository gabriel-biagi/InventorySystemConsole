using System;
using System.Globalization;
using InventorySystem.Models.Exceptions;

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
                $"[{Produto.Codigo}] {Produto.Nome}\n" +
                $"Quantidade: {Quantidade} | " +
                $"Locação: C{Locacao.Coluna} - P{Locacao.Prateleira} - I{Locacao.Item}\n" +
                "----------------------------------------";
        }

        public string ToDetalhadoString()
        {
            return "========================================\n" + " PRODUTO \n" + "========================================\n" + $"Nome : {Produto.Nome}\n" + $"Código : {Produto.Codigo}\n" + $"Quantidade : {Quantidade}\n" + "----------------------------------------\n" + " LOCALIZAÇÃO \n" + "----------------------------------------\n" + $"Coluna : {Locacao.Coluna}\n" + $"Prateleira : {Locacao.Prateleira}\n" + $"Posição : {Locacao.Item}\n" + "========================================";
        }

        public void AdicionaQuantidadeEstoque(decimal quantidade)
        {
            if (quantidade <= 0)
            {
                throw new EstoqueException("Quantidade não pode ser menor do que 0!");
            }

            if (Produto.TipoUnidade == TipoUnidade.Un || Produto.TipoUnidade == TipoUnidade.Pct)
            {
                if (!_verificaNumeroInt(quantidade))
                {
                    throw new EstoqueException("A Quantidade informada não é válida para o tipo de unidade.");
                }
            }

            Quantidade += quantidade;
        }

        public void RemoveQuantidadeEstoque(decimal quantidade)
        {
            if (quantidade < 0)
            {
                throw new EstoqueException("Quantidade não pode ser menor do que 0!");
            }

            if (quantidade > Quantidade)
            {
                throw new EstoqueException("Quantidade informada maior do que disponível em Estoque.");
            }

            if (Produto.TipoUnidade == TipoUnidade.Un || Produto.TipoUnidade == TipoUnidade.Pct)
            {
                if (!_verificaNumeroInt(quantidade))
                {
                    throw new EstoqueException("A Quantidade informada não é válida para o tipo de unidade.");
                }
            }

            Quantidade -= quantidade;
        }

        private bool _verificaNumeroInt(decimal quantidade)
        {
            return quantidade % 1 == 0;
        }
    }
}