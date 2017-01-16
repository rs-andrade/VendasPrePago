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
        void ConsumirCredito(decimal valorConsumo, int IdEstabelecimento);
        void Recarregar(decimal valorRecarga, int IdEstabelecimento, IFilaFaturamento filaFaturamento);
    }
}