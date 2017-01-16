using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutosPrePago.Test.Builder;

namespace ProdutosPrePago.Test
{
    [TestClass]
    public class ContratoTest
    {
        [TestMethod]
        public void DeveRecarregar100ComTaxade3()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(97, contrato.ConsultarSaldo());
            Assert.AreEqual(2, contrato.Movimentacoes.Count);
        }

        [TestMethod]
        public void DeveRecarregar25e25ComTaxade76Centavos()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(25.25m, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(24.49m, contrato.ConsultarSaldo());
            Assert.AreEqual(2, contrato.Movimentacoes.Count);
        }

        [TestMethod]
        public void DeveRecarregar100ComTaxade0()
        {
            var contrato = CriarContrato(0);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(100, contrato.ConsultarSaldo());
            Assert.AreEqual(1, contrato.Movimentacoes.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoParaRecargaException))]
        public void NaoDeveRecarregarMenos100()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(-100, 1, new BuilderFilaFaturamento());
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoParaRecargaException))]
        public void NaoDeveRecarregar0()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(0, 1, new BuilderFilaFaturamento());
        }

        [TestMethod]
        [ExpectedException(typeof(NaoAtingiuValorMinimoRecargaException))]
        public void NaoDeveRecarregar10CentavosComTaxaDe3()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(0.10m, 1, new BuilderFilaFaturamento());
        }

        [TestMethod]
        public void DeveRecarregar100ComTaxade3EConsumir20()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(97, contrato.ConsultarSaldo());
            Assert.AreEqual(2, contrato.Movimentacoes.Count);
            contrato.ConsumirCredito(20, 1);
            Assert.AreEqual(77, contrato.ConsultarSaldo());
        }

        [TestMethod]
        public void DeveRecarregar100ComTaxade3EConsumir97()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(97, contrato.ConsultarSaldo());
            Assert.AreEqual(2, contrato.Movimentacoes.Count);
            contrato.ConsumirCredito(97, 1);
            Assert.AreEqual(0, contrato.ConsultarSaldo());
        }

        [TestMethod]
        [ExpectedException(typeof(SaldoInsuficienteParaConsumoException))]
        public void DeveRecarregar100ComTaxade3ENaoDeveConsumir100()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            Assert.AreEqual(97, contrato.ConsultarSaldo());
            Assert.AreEqual(2, contrato.Movimentacoes.Count);
            contrato.ConsumirCredito(100, 1);            
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoParaConsumoException))]
        public void NaoDeveConsumirMenos100()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            contrato.ConsumirCredito(-100, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoParaConsumoException))]
        public void NaoDeveConsumir0()
        {
            var contrato = CriarContrato(3);
            contrato.Recarregar(100, 1, new BuilderFilaFaturamento());
            contrato.ConsumirCredito(0, 1);
        }

        private static IContrato CriarContrato(decimal taxaRecarga)
        {
            var cliente = new BuilderCliente();
            var produto = new Produto { Id = 1, Descricao = "Produto de Teste", TaxaRecarga = taxaRecarga};
            var contrato = cliente.ContratarProduto(produto);
            return contrato;
        }
    }
}
