using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class ValorInvalidoParaConsumoFault : FaultBase
    {
        public ValorInvalidoParaConsumoFault(string message) : base(message)
        {
        }
    }
}
