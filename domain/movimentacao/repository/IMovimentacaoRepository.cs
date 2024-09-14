
public interface IMovimentacaoRepository {
    Task<Movimentacao> CreateMovimentacao(Movimentacao movimentacao);
    Task<IEnumerable<Movimentacao>> GetAllMovimentacoes();
    Task<Movimentacao> GetMovimentacaoById(int id);
}