using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Producto
    {
        private SqlConnection con = new SqlConnection(Conexion.cadena);
        
        public DataTable D_listar_Productos()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_productos", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string D_agregar_producto(Productos obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_crear_producto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio_Unitario", obj.Precio_Unitario);
                    cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                    if (con.State != ConnectionState.Open) 
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Producto: {obj.Nombre}. ¡Agregado correctamente!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            } 
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public string D_modificar_producto(Productos obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_producto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("id_Producto", obj.id_Producto);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio_Unitario", obj.Precio_Unitario);
                    cmd.Parameters.AddWithValue("@Stock", obj.Stock);

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Producto: {obj.Nombre}. ¡Modificado correctamente!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public string D_eliminar_producto(Productos obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_eliminar_producto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_Producto", obj.id_Producto);
                   
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Producto eliminado correctamente!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    
        public DataTable D_buscar_producto(string nombre)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscar_producto", con))
            {
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre); 

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    
    }
}
