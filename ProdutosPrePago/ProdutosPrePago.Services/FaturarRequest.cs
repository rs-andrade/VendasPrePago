using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Services
{
    public class FaturarRequest
    {
        public int IdCliente { get; set; }
        public string Desccricao { get; set; }
        public decimal Valor { get; set; }
    }
}
