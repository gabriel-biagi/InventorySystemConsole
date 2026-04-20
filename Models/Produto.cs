using System;

namespace InventorySystem.Models
{
    public class Produto
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public TipoUnidade TipoUnidade { get; private set; }

        public Produto(string nome, TipoUnidade tipounidade, int codigo)
        {
            Nome = nome;
            TipoUnidade = tipounidade;
            Codigo = codigo;
        }
    }
}
