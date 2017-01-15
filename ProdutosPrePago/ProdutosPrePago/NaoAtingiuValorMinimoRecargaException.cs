using System;
using System.Runtime.Serialization;

namespace ProdutosPrePago
{
    [Serializable]
    public class NaoAtingiuValorMinimoRecargaException : Exception
    {
        public NaoAtingiuValorMinimoRecargaException()
        {
        }

        public NaoAtingiuValorMinimoRecargaException(string message) : base(message)
        {
        }

        public NaoAtingiuValorMinimoRecargaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NaoAtingiuValorMinimoRecargaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}