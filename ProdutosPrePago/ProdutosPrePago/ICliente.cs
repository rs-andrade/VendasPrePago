using System.Collections.Generic;

namespace ProdutosPrePago
{
    public interface ICliente: IEntity
    {
        IContrato ContratarProduto(Produto produto);
        List<IContrato> ListarContratos();
    }
}