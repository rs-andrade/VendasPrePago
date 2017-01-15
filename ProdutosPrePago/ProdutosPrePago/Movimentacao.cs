using System;

namespace ProdutosPrePago
{
    public class Movimentacao : Entity, IMovimentacao
    {
        public ITipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}