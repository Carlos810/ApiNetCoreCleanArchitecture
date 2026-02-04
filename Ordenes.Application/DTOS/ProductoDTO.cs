using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Application.DTOS
{
    public record ProductoDTO
    (
        int ProductoId,
        string Nombre,
        decimal Precio
    );
}
