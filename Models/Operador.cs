using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class Operador : Funcionario
    {
        public Operador(string nome, int matricula) : base(nome, matricula)
        {
        }

        public string RealizarBaixa(Estoque item, decimal quantidade)
        {
            return item.RemoveQuantidadeEstoque(quantidade);
        }

        public string ReceberMercadoria(Estoque item, decimal quantidade)
        {
            return item.AdicionaQuantidadeEstoque(quantidade);
        }

        public List<Estoque> ListarEstoque(GestaoEstoque ListaDoEstoque)
        {
            return ListaDoEstoque.ListarEstoque();
        }

        public Estoque? BuscarItem(GestaoEstoque ListaDoEstoque, int codigo)
        {
            return ListaDoEstoque.RetornaItemDoEstoque(codigo);
        }
    }
}

