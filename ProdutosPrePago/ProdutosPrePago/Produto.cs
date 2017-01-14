using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago
{
    public class Produto: Entity
    {
        public string Descricao { get; set; }
        public decimal TaxaRecarga { get; set; }
    }
}
