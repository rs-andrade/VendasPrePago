using System;
using System.Collections.Generic;

namespace ProdutosPrePago
{
    public interface IContrato: IEntity
    {
        ICliente Cliente { get; }
        DateTime DataDaContratacao { get; }
        string Identificacao { get; }
        List<IMovimentacao> Movimentacoes { get; }
        IProduto Produto { get; }

        decimal ConsultarSaldo();
        void ConsumirCredito(decimal valorConsumo);
        void Recarregar(decimal valorRecarga, IFilaFaturamento filaFaturamento);
    }
}