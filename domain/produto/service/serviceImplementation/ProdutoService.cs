public class ProdutoService : IProdutoService {
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMovimentacaoRepository _movimentacaoRepository;
    public ProdutoService(IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
    {
        _produtoRepository = produtoRepository;
        _movimentacaoRepository = movimentacaoRepository;
    }
    public async Task<int> CreateProduto(Produto produto)
    {
        return await _produtoRepository.CreateProduto(produto);
    }
    public async Task<IEnumerable<Produto>> GetAllProdutos()
    {
        return await _produtoRepository.GetAllProdutos();
    }
    public async Task<Produto> GetProdutoById(int id)
    {
        return await _produtoRepository.GetProdutoById(id);
    }
    public async Task<Produto> MovimentaProduto(int id, int quantidade)
    {
        var produto = await _produtoRepository.GetProdutoById(id);
        if (produto == null)
        {
            return null;
        }

        if(produto.Saldo + quantidade < 0)
        {
            throw new Exception("Saldo insuficiente");
        }

        String tipo = quantidade > 0 ? "entrada" : "saida";

        Movimentacao movimentacao = new Movimentacao(id, tipo, quantidade);

        produto.Saldo += quantidade;

           await _movimentacaoRepository.CreateMovimentacao(movimentacao);
           await _produtoRepository.MovimentaProduto(id, quantidade);

        return produto;
    }
}