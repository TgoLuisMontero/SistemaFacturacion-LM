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
    public class CD_Usuario
    {
        private SqlConnection con = new SqlConnection(Conexion.cadena);
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (con)
            {
                try
                {
                    string query = "select id_Usuario, Codigo_Usuario, NombreCompleto, Telefono, Email, Direccion" +
                        " from tb_Usuarios";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuarios()
                            {
                                id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                Codigo_Usuario = dr["Codigo_Usuario"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Email = dr["Email"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuarios>();
                }
            }

            return lista;
        }
        
        public DataTable D_listar_usuarios()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_usuarios", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string D_agregar_usuario(Usuarios obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_crear_usuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo_Usuario", obj.Codigo_Usuario);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    if (con.State != ConnectionState.Open) 
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Usuario: {obj.NombreCompleto} agregado correctamente!";
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

        public string D_modificar_usuario(Usuarios obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_actualizar_usuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_Usuario", obj.id_Usuario);
                    cmd.Parameters.AddWithValue("@Codigo_Usuario", obj.Codigo_Usuario);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return $"Usuario: {obj.NombreCompleto} modificado correctamente!";
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

        public string D_eliminar_usuario(Usuarios obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_eliminar_usuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_Usuario", obj.id_Usuario);
                   
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Usuario eliminado correctamente!";
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
    
        public DataTable D_buscar_usuario(string nombre)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscar_usuario", con))
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
