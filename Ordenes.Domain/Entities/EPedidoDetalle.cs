using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Domain.Entities
{
    public class EPedidoDetalle
    {
        public int PedidoDetalleId { get; private set; }
        public int PedidoId { get; private set; }
        public int ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }

        public EPedidoDetalle()
        {
            
        }

        public EPedidoDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
