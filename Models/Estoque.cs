using System;

namespace InventorySystem.Models
{
    public class Estoque
    {
        public Produto Produto { get; private set; }
        public Locacao Locacao { get; private set; }
        public decimal Quantidade { get; private set; }


        public Estoque(Produto produto, Locacao locacao, decimal quantidade)
        {
            Produto = produto;
            Locacao = locacao;
            Quantidade = quantidade;
        }
    }
}