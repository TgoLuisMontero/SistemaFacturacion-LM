using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int id_Cliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string FechaRegistro { get; set; }
    }
}
