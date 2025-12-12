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
    public class CD_Cliente
    {
        private SqlConnection con = new SqlConnection(Conexion.cadena);
        
        public DataTable D_listar_clientes()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_cientes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string D_agregar_cliente(Cliente obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_crear_cliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    if (con.State != ConnectionState.Open) 
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Cliente: {obj.NombreCompleto} agregado correctamente!";
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

        public string D_modificar_cliente(Cliente obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_actualizar_cliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_Cliente", obj.id_Cliente);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Cliente: {obj.NombreCompleto} modificado correctamente!";
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

        public string D_eliminar_cliente(Cliente obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_eliminar_cliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_Cliente", obj.id_Cliente);
                   
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Cliente eliminado correctamente!";
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
    
        public DataTable D_buscar_cliente(string nombre)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscar_cliente", con))
            {
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCompleto", nombre); 

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    
    }
}
