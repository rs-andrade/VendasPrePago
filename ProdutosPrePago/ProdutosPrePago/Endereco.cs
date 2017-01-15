using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutosPrePago
{
    public class Endereco: Entity
    {
        public Cidade Cidade { get; set; }        
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
    }
}