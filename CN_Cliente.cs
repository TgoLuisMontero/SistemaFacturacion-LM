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
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public string CN_crear_Cliente(Cliente obj)
        {
            return objcd_cliente.D_agregar_cliente(obj);
        }

        public string CN_modificar_Cliente(Cliente obj)
        {
            return objcd_cliente.D_modificar_cliente(obj);
        }

        public string CN_eliminar_Cliente(Cliente obj)
        {
            return objcd_cliente.D_eliminar_cliente(obj);
        }

        public DataTable CN_buscar_Cliente(string nombre)
        {
            return objcd_cliente.D_buscar_cliente(nombre);
        }
        public DataTable CN_listarClientes()
        {
            return objcd_cliente.D_listar_clientes();
        }  
    }
}
