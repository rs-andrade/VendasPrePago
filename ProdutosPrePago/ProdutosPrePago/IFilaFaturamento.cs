namespace ProdutosPrePago
{
    public interface IFilaFaturamento
    {
        void IncluirNaFila(Fatura fatura);
    }
}