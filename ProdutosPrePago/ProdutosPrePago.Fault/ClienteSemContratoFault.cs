using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class ClienteSemContratoFault : FaultBase
    {
        public ClienteSemContratoFault(string message) : base(message)
        {
        }
    }
}
