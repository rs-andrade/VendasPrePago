using System;
using System.Runtime.Serialization;

namespace ProdutosPrePago
{
    [Serializable]
    public class ValorInvalidoParaConsumoException : Exception
    {
        public ValorInvalidoParaConsumoException()
        {
        }

        public ValorInvalidoParaConsumoException(string message) : base(message)
        {
        }

        public ValorInvalidoParaConsumoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorInvalidoParaConsumoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}