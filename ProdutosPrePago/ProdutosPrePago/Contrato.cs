using ProdutosPrePago.TiposMovimentacao;
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
        public string Identificacao { get; set; }      
        public List<Movimentacao> Movimentacoes { get; private set; }
        public DateTime DataDaContratacao { get; set; }

        public void Recarregar(decimal valorRecarga)
        {
            if (valorRecarga <= 0)
                throw new ValorInvalidoParaRecargaException();
                
            var movimentacaoRecarga = new Movimentacao {
                Data = DateTime.Now,
                Valor = valorRecarga,
                Tipo = new TipoMovimentacaoRecarga { TipoDaMovimentacao = TipoMovimentacaoEnum.Recarga}
            };

            Movimentacao movimentacaoTaxa = null;
            decimal valorTaxa = Produto.ValorTaxa(valorRecarga);
            if (valorTaxa > 0)
            {
                var fatura = new Fatura {
                    IdCliente = Cliente.Id,
                    Valor = valorTaxa,
                    Descricao = Produto.Descricao
                };
                FilaFaturamento.IncluirNaFila(fatura);            
                movimentacaoTaxa = new Movimentacao
                {
                    Data = DateTime.Now,
                    Valor = -valorTaxa,
                    Tipo = new TipoMovimentacaoTaxaRecarga { TipoDaMovimentacao = TipoMovimentacaoEnum.TaxaRecarga, PercentualTaxa = Produto.TaxaRecarga }
                };
            }
            Movimentacoes.Add(movimentacaoRecarga);
            if (movimentacaoTaxa != null)
                Movimentacoes.Add(movimentacaoRecarga);
        }

        public void ConsumirCredito(decimal valorConsumo)
        {
            if (valorConsumo <= 0)
                throw new ValorInvalidoParaConsumoException();

            if (valorConsumo <= ConsultarSaldo())
            {
                var movimentacaoRecarga = new Movimentacao
                {
                    Data = DateTime.Now,
                    Valor = -valorConsumo,
                    Tipo = new TipoMovimentacaoConsumo { TipoDaMovimentacao = TipoMovimentacaoEnum.Recarga }
                };
            }
            else
                throw new SaldoInsuficienteParaConsumoException();
        }

        public decimal ConsultarSaldo()
        {
            return Movimentacoes.Sum(x => x.Valor);
        }

        public static Contrato ConsultarPorIdContrato(int IdContrato)
        {
            throw new NotImplementedException();
        }
    }
}
