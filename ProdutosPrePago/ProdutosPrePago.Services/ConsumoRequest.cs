using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Services
{
    public class ConsumoRequest
    {
        public int IdContrato { get; set; }
        public int IdEstabelecimento { get; set; }
        public decimal ValorConsumo { get; set; }
    }
}
