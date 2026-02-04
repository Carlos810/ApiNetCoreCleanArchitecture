using Ordenes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.Interfaces
{
    public interface IPedidoRepository
    {
        EPedido Crear(EPedido pedido);
        EPedido? ObtenerPorId(int pedidoId);
        IEnumerable<EPedido> ObtenerTodos();
    }
}
