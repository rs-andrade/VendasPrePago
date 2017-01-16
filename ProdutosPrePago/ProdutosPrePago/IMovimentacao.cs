using System;

namespace ProdutosPrePago
{
    public interface IMovimentacao: IEntity
    {
        DateTime Data { get; set; }
        ITipoMovimentacao Tipo { get; set; }
        int IdEstabelecimento { get; set; }
        decimal Valor { get; set; }
    }
}