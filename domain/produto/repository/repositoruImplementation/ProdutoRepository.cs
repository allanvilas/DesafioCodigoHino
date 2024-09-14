using System.Data;
using Dapper;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IDbConnection _dbConnection;

    public ProdutoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<int> CreateProduto(Produto produto)
    {
        var sql = @"
    INSERT INTO Produtos (sku, Descricao, data_cadastro, data_movimentacao, saldo) 
    VALUES (@Sku, @Descricao, @DataCadastro, @DataMovimentacao, @Saldo)
    RETURNING Id;";
        var id = _dbConnection.ExecuteScalarAsync<int>(sql, produto);
        return id;
    }

    public async Task<IEnumerable<Produto>> GetAllProdutos()
    {
        var sql = "SELECT * FROM Produtos ";
        return await _dbConnection.QueryAsync<Produto>(sql);
    }

    public async Task<Produto> GetProdutoById(int id)
    {
        var sql = "SELECT * FROM Produtos  WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
    }

    public async Task<Produto> MovimentaProduto(int id, int quantidade)
    {
        var produto = await GetProdutoById(id);
        if (produto == null)
        {
            return null;
        }

        var saldo = produto.Saldo + quantidade;
        var sql = "UPDATE Produtos SET Saldo = @Saldo, data_movimentacao = CURRENT_TIMESTAMP WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Saldo = saldo, Id = id });

        return await GetProdutoById(id);
    }
}