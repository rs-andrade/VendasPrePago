using ProdutosPrePago.TiposMovimentacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago
{
    public class Contrato : Entity, IContrato
    {
        public ICliente Cliente { get; private set; }
        public IProduto Produto { get; private set; }  
        public string Identificacao { get; private set; }      
        public List<IMovimentacao> Movimentacoes { get; private set; }
        public DateTime DataDaContratacao { get; private set; }

        public Contrato(ICliente cliente, IProduto produto, string identificacao)
        {
            Cliente = cliente;
            Produto = produto;
            Identificacao = identificacao;
            DataDaContratacao = DateTime.Now.Date;
        }

        public void Recarregar(decimal valorRecarga, IFilaFaturamento filaFaturamento)
        {
            if (valorRecarga <= 0)
                throw new ValorInvalidoParaRecargaException();
                
            var movimentacaoRecarga = new Movimentacao {
                Data = DateTime.Now.Date,
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
                filaFaturamento.IncluirNaFila(fatura);            
                movimentacaoTaxa = new Movimentacao
                {
                    Data = DateTime.Now.Date,
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
                    Data = DateTime.Now.Date,
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
