using System;
using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class GestaoEstoque
    {
        public List<Estoque> ItensEstoque { get; private set; }
        public GestaoEstoque()
        {
            ItensEstoque = new List<Estoque>();
        }

        public void AdicionarAoEstoque(Estoque estoque)
        {
            ItensEstoque.Add(estoque);
        }

        public List<Estoque> ListarEstoque()
        {
            return ItensEstoque;
        }

        public string RemoverDoEstoque(int codigoProduto)
        {
            Estoque item = produtoExiste(codigoProduto);

            if (item == null)
            {
                return "Erro, Código não encontrado.";
            } else
            {
                ItensEstoque.Remove(item);
                return null;
            }
        }

        private Estoque? produtoExiste(int codigoProduto)
        {
            return ItensEstoque.Find(produto => produto.Produto.Codigo == codigoProduto);
        }

        public Estoque? retornaItemDoEstoque(int codigoProduto)
        {
            return ItensEstoque.Find(produto => produto.Produto.Codigo == codigoProduto);
        }
    }
}
