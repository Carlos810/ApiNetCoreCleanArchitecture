using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ordenes.Application.DTOS
{
    public record ClienteDTO
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public DateTime FechaRegistro { get; set; }

    };
}
