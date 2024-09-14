public interface IProdutoRepository 
{
    Task<int> CreateProduto(Produto produto);
    Task<IEnumerable<Produto>> GetAllProdutos();
    Task<Produto> GetProdutoById(int id);
    Task<Produto> MovimentaProduto(int id, int quantidade);

}