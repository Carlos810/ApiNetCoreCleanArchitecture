using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes.Domain.Entities
{
    public class EProductos
    {
        public int ProductoId { get; private set; }
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public bool Activo { get; private set; }

        public EProductos()
        {
            
        }

        public EProductos(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
            Activo = true;
        }
    }
}
