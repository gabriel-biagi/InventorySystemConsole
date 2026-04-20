using System;

namespace InventorySystem.Models
{
    public class Locacao
    {
        public int Coluna { get; private set; }
        public int Prateleira { get; private set; }
        public int Item { get; private set; }



        public Locacao(int coluna, int prateleira, int item)
        {
            Coluna = coluna;
            Prateleira = prateleira;
            Item = item;
        }
    }
}
