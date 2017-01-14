using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Services
{
    public class ConsumoRequest
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorConsumo { get; set; }
    }
}
