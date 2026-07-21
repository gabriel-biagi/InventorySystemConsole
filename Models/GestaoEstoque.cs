using System;
using System.Collections.Generic;
using InventorySystem.Persistence;
using System.Linq;

namespace InventorySystem.Models
{
    public class GestaoEstoque
    {
        public List<Estoque> ItensEstoque { get; private set; }
        public GestaoEstoque()
        {
            ItensEstoque = new List<Estoque>();
        }

        public GestaoEstoque(List<Estoque> itens)
        {
            ItensEstoque = itens;
        }

        public void AdicionarAoEstoque(Estoque estoque)
        {
            ItensEstoque.Add(estoque);
        }

        public List<Estoque> ListarEstoque()
        {
            return ItensEstoque;
        }

        public void RemoverDoEstoque(Estoque estoque)
        {
            ItensEstoque.Remove(estoque);
        }


        public Estoque? RetornaItemDoEstoque(int codigoProduto)
        {
            return ItensEstoque.FirstOrDefault(x => x.Produto.Codigo == codigoProduto);
        }
    }
}
