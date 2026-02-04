using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Domain.Entities
{
    public class EClientes
    {
        public int ClienteId { get;  set; }
        public string? Nombre { get;  set; }
        public string? Email { get;  set; }
        public DateTime FechaDeRegistro { get;  set; }

    }
}
