using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Facturas
    {
        public int id_Factura { get; set; }
        public Cliente obj_Cliente { get; set; }
        public Usuarios obj_Usuario { get; set; }    
        public Cliente obj_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total_Bruto { get; set; }
        public double Impuestos { get; set; }
        public double Total_Neto { get; set; }
        public string FechaRegistro { get; set; }
    }
}
