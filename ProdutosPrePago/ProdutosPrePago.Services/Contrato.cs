using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Services
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Identificacao { get; set; }
        public string DescricaoProduto { get; set; }
    }
}
