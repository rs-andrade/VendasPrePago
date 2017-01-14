using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Fault
{
    public class FaultBase
    {
        private string report;

        public FaultBase(string message)
        {
            this.report = message;
        }

        public string Message
        {
            get { return this.report; }
            set { this.report = value; }
        }
    }
}
