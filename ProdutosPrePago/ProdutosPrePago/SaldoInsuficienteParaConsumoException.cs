using System;
using System.Runtime.Serialization;

namespace ProdutosPrePago
{
    [Serializable]
    public class SaldoInsuficienteParaConsumoException : Exception
    {
        public SaldoInsuficienteParaConsumoException()
        {
        }

        public SaldoInsuficienteParaConsumoException(string message) : base(message)
        {
        }

        public SaldoInsuficienteParaConsumoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaldoInsuficienteParaConsumoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}