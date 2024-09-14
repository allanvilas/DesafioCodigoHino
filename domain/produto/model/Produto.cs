

public class Produto {

    public long Id {get;set;}
    public String Sku {get;set;}
    public String Descricao {get;set;}
    public DateTime DataCadastro {get;set;}
    public DateTime DataMovimentacao {get;set;}
    public int Saldo {get; set;}

    public Produto(){ }
    public Produto(long id, string sku, string descricao, DateTime dataCadastro, DateTime dataMovimentacao, int saldo)
    {
        Id = id;
        Sku = sku;
        Descricao = descricao;
        DataCadastro = dataCadastro;
        DataMovimentacao = dataMovimentacao;
        Saldo = saldo;
    }
}