using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.DTOS
{
    public record PedidoDTO
    (
        int PedidoId,
        int ClienteId,
        DateTime FechaPedido,
        string Estado,
        IEnumerable<PedidoDetalleDTO> Detalles
        );
}
