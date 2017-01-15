using System;
using System.Runtime.Serialization;

namespace ProdutosPrePago
{
    [Serializable]
    public class ValorInvalidoParaRecargaException : Exception
    {
        public ValorInvalidoParaRecargaException()
        {
        }

        public ValorInvalidoParaRecargaException(string message) : base(message)
        {
        }

        public ValorInvalidoParaRecargaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorInvalidoParaRecargaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}