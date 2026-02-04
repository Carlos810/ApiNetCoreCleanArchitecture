using Ordenes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordenes.Application.Interfaces;

namespace Ordenes.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private static readonly List<EPedido> _pedidos = new();
        private static int _id = 1;

        public EPedido Crear(EPedido pedido)
        {
            typeof(EPedido)
                .GetProperty(nameof(EPedido.PedidoId))!
                .SetValue(pedido, _id++);

            _pedidos.Add(pedido);
            return pedido;
        }

        public EPedido? ObtenerPorId(int pedidoId)
            => _pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);

        public IEnumerable<EPedido> ObtenerTodos()
            => _pedidos;
    }
}
