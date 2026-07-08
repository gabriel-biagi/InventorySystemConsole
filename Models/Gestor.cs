
namespace InventorySystem.Models
{
    public sealed class Gestor : Operador
    {
        public Gestor(string nome, int matricula) : base(nome, matricula)
        {
        }

        public void CadastrarProduto(Produto produto, Locacao locacao, decimal quantidade, GestaoEstoque ItensEstoque)
        {
            Estoque estoque = new Estoque(produto, locacao, quantidade);
            ItensEstoque.AdicionarAoEstoque(estoque);
        }

        public void AlterarNome(Produto produto, string novoNome)
        {
            produto.AlterarNome(novoNome);
        }

        public void ExcluirProduto(GestaoEstoque estoque, Estoque produto)
        {
            estoque.RemoverDoEstoque(produto);
        }

        public void EstornarProduto(Estoque produto, decimal quantidade)
        {
            produto.AdicionaQuantidadeEstoque(quantidade);       
        }
    }
}
