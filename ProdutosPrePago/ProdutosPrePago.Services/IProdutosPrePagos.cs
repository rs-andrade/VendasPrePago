using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProdutosPrePago.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProdutosPrePagos" in both code and config file together.
    [ServiceContract]
    public interface IProdutosPrePagos
    {
        [OperationContract]
        ConultarContratosResponse ConsultarContratosService(ConsultarContratosRequest consultarContratosRequest);

        [OperationContract]
        void RecargaService(RecargaRequest recargaRequest);

        [OperationContract]
        void ConsumoService(ConsumoRequest consumoRequest);

        [OperationContract]
        ConsultaSaldoResponse ConsultaSaldoService(ConsultaSaldoRequest consultaSaldoRequest);
    }
}
