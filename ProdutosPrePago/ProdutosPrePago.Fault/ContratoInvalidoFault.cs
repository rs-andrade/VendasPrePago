using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class ContratoInvalidoFault : FaultBase
    {
        public ContratoInvalidoFault(string message) : base(message)
        {
        }
    }
}
