using System;

namespace ProdutosPrePago
{
    public class Movimentacao: Entity
    {
        public TipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}