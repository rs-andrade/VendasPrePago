using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago.Test.Builder
{
    public class BuilderCliente : ICliente
    {
        public int Id { get; set; }

        public IContrato ContratarProduto(IProduto produto)
        {
            return new Contrato(this, produto, "Meu carro");
        }

        public List<IContrato> ListarContratos()
        {
            throw new NotImplementedException();
        }
    }
}
