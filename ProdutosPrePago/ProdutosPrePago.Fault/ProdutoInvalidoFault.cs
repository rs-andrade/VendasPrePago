using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class ProdutoInvalidoFault : FaultBase
    {
        public ProdutoInvalidoFault(string message) : base(message)
        {
        }
    }
}
