public class Movimentacao {

    public int Id {get;set;}
    public int IdProduto {get;set;}
    public String Tipo {get;set;}
    public int Quantidade {get;set;}
    public DateTime Data {get;set;}

    public Movimentacao(){ }
    public Movimentacao(int idProduto, string tipo, int quantidade)
    {
        IdProduto = idProduto;
        Tipo = tipo;
        Quantidade = quantidade;
    }

}