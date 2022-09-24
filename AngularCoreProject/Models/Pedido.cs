using System;
using System.Collections.Generic;

namespace AngularCoreProject.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            LineasPedidos = new HashSet<LineasPedido>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<LineasPedido> LineasPedidos { get; set; }
    }
}
