using System;

namespace InventorySystem.Models
{
    public class Produto
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public TipoUnidade TipoUnidade { get; private set; }

        public Produto(string nome, int codigo, TipoUnidade tipounidade)
        {
            Nome = nome;
            Codigo = codigo;
            TipoUnidade = tipounidade;
        }
    }
}
