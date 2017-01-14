using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class ClienteInvalidoFault : FaultBase
    {
        public ClienteInvalidoFault(string message) : base(message)
        {
        }
    }
}
