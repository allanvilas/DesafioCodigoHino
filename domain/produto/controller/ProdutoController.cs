
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[ApiController]	
[Route("api/[controller]")]
public class ProdutoController : ControllerBase {
    private readonly IProdutoService _produtoService;


    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    

    [HttpGet]
    public async Task<IEnumerable<Produto>> GetAllProdutos()
    {
        return await _produtoService.GetAllProdutos();
    }

    [HttpGet("{id}")]
    public async Task<Produto> GetProdutoById(int id)
    {
        return await _produtoService.GetProdutoById(id);
    }

    [HttpPut("{id}/{quantidade}")]
    public async Task<Produto> MovimentaProduto(int id, int quantidade)
    {
        return await _produtoService.MovimentaProduto(id, quantidade);
    }

    [HttpPost]
    public async Task<int> CreateProduto(Produto produto)
    {
        return await _produtoService.CreateProduto(produto);

    }

}