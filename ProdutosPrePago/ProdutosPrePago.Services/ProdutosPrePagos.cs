using ProdutosPrePago.Fault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProdutosPrePago.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProdutosPrePagos" in both code and config file together.
    public class ProdutosPrePagos : IProdutosPrePagos
    {
        public ConultarContratosResponse ConsultarContratosService(ConsultarContratosRequest consultarContratosRequest)
        {
            var cliente = ConsultarClientePorId(consultarContratosRequest.IdCliente);

            var resultado = cliente.ListarContratos();

            List<Contrato> retorno = new List<Contrato>();

            resultado.ForEach(x => retorno.Add(new Contrato
            {
                IdContrato = x.Id,
                DataContratacao = x.DataDaContratacao,
                DescricaoProduto = x.Produto.Descricao,
                Identificacao = x.Identificacao
            }));

            return new ConultarContratosResponse { Contratos = retorno};
        }

        public ConsultaSaldoResponse ConsultaSaldoService(ConsultaSaldoRequest consultaSaldoRequest)
        {
            var contrato = ConsultarContratoPorId(consultaSaldoRequest.IdContrato);

            return new ConsultaSaldoResponse {Saldo = contrato.ConsultarSaldo() };
        }

        public void ConsumoService(ConsumoRequest consumoRequest)
        {
            var contrato = ConsultarContratoPorId(consumoRequest.IdContrato);
            try
            {
                contrato.ConsumirCredito(consumoRequest.ValorConsumo);
            }
            catch (ValorInvalidoParaConsumoException ex)
            {
                throw new FaultException<ValorInvalidoParaConsumoFault>(new ValorInvalidoParaConsumoFault(ex.Message));
            }
            catch (SaldoInsuficienteParaConsumoException ex)
            {
                throw new FaultException<SaldoInsuficienteParaConsumoFault>(new SaldoInsuficienteParaConsumoFault(ex.Message));
            }
        }        

        public void RecargaService(RecargaRequest recargaRequest)
        {
            var contrato = ConsultarContratoPorId(recargaRequest.IdContrato);
            
            try
            {
                contrato.Recarregar(recargaRequest.ValorRecarga, new FilaFaturamento());
            }
            catch (ValorInvalidoParaRecargaException ex)
            {
                throw new FaultException<ValorInvalidoParaRecargaFault>(new ValorInvalidoParaRecargaFault(ex.Message));
            }
            catch (NaoAtingiuValorMinimoRecargaException ex)
            {
                throw new FaultException<NaoAtingiuValorMinimoRecargaFault>(new NaoAtingiuValorMinimoRecargaFault(ex.Message));
            }
        }

        private static ProdutosPrePago.Contrato ConsultarContratoPorId(int IdContrato)
        {
            var contrato = ProdutosPrePago.Contrato.ConsultarPorIdContrato(IdContrato);

            if (contrato == null)
                throw new FaultException<ContratoInvalidoFault>(new Fault.ContratoInvalidoFault(string.Format("Contrato com Id:{0} não localizado",
                    IdContrato)));
            return contrato;
        }

        private static ProdutosPrePago.Cliente ConsultarClientePorId(int IdCliente)
        {
            var cliente = ProdutosPrePago.Cliente.ConsultarPorIdCliente(IdCliente);

            if (cliente == null)
                throw new FaultException<ClienteInvalidoFault>(new Fault.ClienteInvalidoFault(string.Format("Cliente com Id:{0} não localizado",
                    IdCliente)));
            return cliente;
        }
    }
}
