namespace ProdutosPrePago
{
    public interface IProduto: IEntity
    {
        string Descricao { get; set; }
        decimal TaxaRecarga { get; set; }

        decimal ValorTaxa(decimal valorRecarga);
    }
}