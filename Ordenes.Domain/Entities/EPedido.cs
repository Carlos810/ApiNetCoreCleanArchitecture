using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Domain.Entities
{
    public class EPedido
    {
        public int PedidoId { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime FechaPedido { get; private set; }
        public string Estado { get; private set; }

        private readonly List<EPedidoDetalle> _detalles = new();
        public IReadOnlyCollection<EPedidoDetalle> Detalles => _detalles;


        public EPedido(int clienteId,string estado)
        {
            ClienteId = clienteId;
            Estado = estado;
            FechaPedido = DateTime.UtcNow;
        }

        public void AgregarDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            _detalles.Add(new EPedidoDetalle ( productoId,cantidad, precioUnitario ) );
        }

    }
}
