using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[ApiController]	
[Route("api/[controller]")]
public class MovimentacaoController {
    private readonly IMovimentacaoRepository _movimentacaoRepository;
    public MovimentacaoController(IMovimentacaoRepository movimentacaoRepository)
    {
        _movimentacaoRepository = movimentacaoRepository;
    }

    [HttpGet("movimentacao/{id}")]
    public async Task<Movimentacao> GetMovimentacaoByProdutoId(int id)
    {
        return await _movimentacaoRepository.GetMovimentacaoById(id);
    }

    [HttpGet]
    public async Task<IEnumerable<Movimentacao>> GetAllMovimentacao()
    {
        return await _movimentacaoRepository.GetAllMovimentacoes();
    }
}