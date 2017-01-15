using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago
{
    public class Produto: Entity
    {
        public string Descricao { get; set; }
        public decimal TaxaRecarga { get; set; }

        public decimal ValorTaxa(decimal valorRecarga)
        {
            if (TaxaRecarga > 0)
            {
                var valorTaxa = Math.Round(valorRecarga * TaxaRecarga, 2);
                if (valorTaxa == 0)
                    throw new NaoAtingiuValorMinimoRecargaException();
                return valorTaxa;
            }
            else
                return 0;
            
        }
    }
}
