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
        public void RemoverDoEstoque(Estoque estoque)
        {
            ItensEstoque.Remove(estoque);
        }
    }
}
