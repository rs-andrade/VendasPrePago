using System.Collections.Generic;

namespace ProdutosPrePago
{
    public interface ICliente: IEntity
    {
        IContrato ContratarProduto(IProduto produto);
        List<IContrato> ListarContratos();
    }
}