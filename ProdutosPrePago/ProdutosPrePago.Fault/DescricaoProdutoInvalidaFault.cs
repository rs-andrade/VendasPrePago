using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class DescricaoProdutoInvalidaFault : FaultBase
    {
        public DescricaoProdutoInvalidaFault(string message) : base(message)
        {
        }
    }
}
