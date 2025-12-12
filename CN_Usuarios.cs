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
    public class CN_Usuarios
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuarios> Listar()
        {
            return objcd_usuario.Listar();
        }

        public string CN_crear_Usuarios(Usuarios obj)
        {
            return objcd_usuario.D_agregar_usuario(obj);
        }

        public string CN_modificar_Usuarios(Usuarios obj)
        {
            return objcd_usuario.D_modificar_usuario(obj);
        }

        public string CN_eliminar_Usuarios(Usuarios obj)
        {
            return objcd_usuario.D_eliminar_usuario(obj);
        }

        public DataTable CN_buscar_usuario(string nombre)
        {
            return objcd_usuario.D_buscar_usuario(nombre);
        }
        public DataTable CN_listarUsuarios()
        {
            return objcd_usuario.D_listar_usuarios();
        }
        
    }
}
