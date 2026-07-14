using System.Collections.Generic;
using InventorySystem.Interfaces;

namespace InventorySystem.Models
{
    public class Operador : Funcionario, IFuncionario
    {
        public Operador(string nome, int matricula) : base(nome, matricula)
        {
        }

        public void RealizarBaixa(Estoque item, decimal quantidade)
        {
            item.RemoveQuantidadeEstoque(quantidade);
        }

        public void ReceberMercadoria(Estoque item, decimal quantidade)
        {
            item.AdicionaQuantidadeEstoque(quantidade);
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

