using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago
{
    public class Contrato: Entity
    {
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }        
        public List<Movimentacao> Movimentacoes {get; }
        public DateTime DataDaContratacao { get; set; }

        public void Recarregar(decimal valorRecarga)
        {

        }

        public void ConsumirCredito(decimal valorConsumo)
        {

        }

        public decimal ConsultarSaldo()
        {
            throw new NotImplementedException();
        }
    }
}
