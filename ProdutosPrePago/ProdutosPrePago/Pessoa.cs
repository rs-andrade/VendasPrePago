using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutosPrePago
{
    public abstract class Pessoa : Entity
    {
        public TipoPessoa TipoPessoa { get; set; }

        public string DocumentoIdentificacao { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}