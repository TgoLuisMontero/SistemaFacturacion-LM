using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Productos
    {
        public int id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio_Unitario { get; set; }
        public int Stock { get; set; }
        public string FechaRegistro { get; set; }
    }
}
