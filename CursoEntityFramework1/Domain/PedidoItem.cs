﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEntityFramework1.Domain {
    public class PedidoItem {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }

    }
}
