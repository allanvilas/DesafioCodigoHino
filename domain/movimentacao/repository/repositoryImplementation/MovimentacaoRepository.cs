using System.Data;
using Dapper;

public class MovimentacaoRepository : IMovimentacaoRepository {
    private readonly IDbConnection _dbConnection;

    public MovimentacaoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Movimentacao> CreateMovimentacao(Movimentacao movimentacao)
    {
        var sql = @"
            INSERT INTO movimentacao (id_produto, tipo, quantidade) 
            VALUES (@IdProduto, @Tipo, @Quantidade)";
        await _dbConnection.ExecuteAsync(sql, movimentacao);
        
        return await GetMovimentacaoById(movimentacao.Id);
    }

    public async Task<IEnumerable<Movimentacao>> GetAllMovimentacoes()
    {
        var sql = "SELECT * FROM movimentacao ";
        return await _dbConnection.QueryAsync<Movimentacao>(sql);
    }

    public async Task<Movimentacao> GetMovimentacaoById(int id)
    {
        var sql = "SELECT * FROM movimentacao  WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Movimentacao>(sql, new { Id = id });
    }

}