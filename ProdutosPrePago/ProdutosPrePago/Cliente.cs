﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosPrePago
{
    public class Cliente : Entity, ICliente
    {
        public IContrato ContratarProduto(IProduto produto)
        {
            throw new NotImplementedException();
        }

        public List<IContrato> ListarContratos()
        {
            throw new NotImplementedException();
        }

        public static Cliente ConsultarPorIdCliente(int IdCliente)
        {
            throw new NotImplementedException();
        }
    }
}
