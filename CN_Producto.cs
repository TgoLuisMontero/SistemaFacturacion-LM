using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_producto = new CD_Producto();

        public string CN_crear_Producto(Productos obj)
        {
            return objcd_producto.D_agregar_producto(obj);
        }

        public string CN_modificar_Producto(Productos obj)
        {
            return objcd_producto.D_modificar_producto(obj);
        }

        public string CN_eliminar_Producto(Productos obj)
        {
            return objcd_producto.D_eliminar_producto(obj);
        }

        public DataTable CN_buscar_Producto(string nombre)
        {
            return objcd_producto.D_buscar_producto(nombre);
        }
        public DataTable CN_listarProductos()
        {
            return objcd_producto.D_listar_Productos();
        }
        
    }
}
