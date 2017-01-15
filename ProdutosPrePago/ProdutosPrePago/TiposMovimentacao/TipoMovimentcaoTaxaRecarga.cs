using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.TiposMovimentacao
{
    public class TipoMovimentcaoTaxaRecarga : TipoMovimentacao
    {
        public decimal PercentualTaxa { get; set; }
    }
}