using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Models;

namespace InventorySystem.Interfaces
{
    public interface IFuncionario
    {
        public void RealizarBaixa(Estoque item, decimal quantidade);

        public void ReceberMercadoria(Estoque item, decimal quantidade);

        public List<Estoque> ListarEstoque(GestaoEstoque ListaDoEstoque);

        public Estoque? BuscarItem(GestaoEstoque ListaDoEstoque, int codigo);
    }
}
