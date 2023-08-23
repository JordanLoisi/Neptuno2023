using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private string cadenaConexion;
        public RepositorioProveedores()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Borrar(int ProveedorId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Proveedores WHERE ProveedorId=@ProveedorId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@ProveedorId", SqlDbType.Int);
                    comando.Parameters["@ProveedorId"].Value = ProveedorId;

                    comando.ExecuteNonQuery();
                }
            }

        }

        public void Editar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Proveedores SET NombreProveedor=@NombreProveedor,
                                Direccion=@Direccion, 
                                CodPostal=@CodPostal, PaisId=@PaisId, 
                                CiudadId=@CiudadId,  
                                Telefono=@Telefono, Email=@Email 
                                WHERE ProveedorId=@ProveedorId";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@NombreProveedor", SqlDbType.NVarChar);
                    cmd.Parameters["@NombreProveedor"].Value = proveedor.NombreProveedor;

                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = proveedor.Direccion;

                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = proveedor.CodPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = proveedor.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = proveedor.CiudadId;

                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar);
                    cmd.Parameters["@Telefono"].Value = proveedor.Telefono;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                    cmd.Parameters["@Email"].Value = proveedor.Email;


                    cmd.Parameters.Add("@ProveedorId", SqlDbType.Int);
                    cmd.Parameters["@ProveedorId"].Value = proveedor.ProveedorId;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool Existe(Proveedor proveedor)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery;
                if (proveedor.ProveedorId == 0)
                {
                    selectQuery = "SELECT COUNT(*) FROM Proveedores WHERE NombreProveedor=@Nombre AND Apellido=@Apellido";

                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Proveedores WHERE NombreProveedor=@Nombre AND ProveedorId=@ProveedorId";

                }
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                    comando.Parameters["@Nombre"].Value = proveedor.NombreProveedor;


                    if (proveedor.ProveedorId != 0)
                    {
                        comando.Parameters.Add("@ProveedorId", SqlDbType.Int);
                        comando.Parameters["@ProveedorId"].Value = proveedor.ProveedorId;

                    }

                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }


        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Proveedores";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad;


        }

        public List<Proveedor> GetProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = @"SELECT *
                        FROM Proveedores 
                        ORDER BY NombreProveedor";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proveedorDto = ConstruirProveedor(reader);
                            lista.Add(proveedorDto);
                        }
                    }
                }
            }
            return lista;
        }

        public List<Proveedor> GetProveedoresPorPagina(int cantidad, int pagina)
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                    FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                    INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                    ORDER BY NombreProveedor
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidadPorPagina ROWS ONLY";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                    comando.Parameters["@cantidadRegistros"].Value = cantidad * (pagina - 1);

                    comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                    comando.Parameters["@cantidadPorPagina"].Value = cantidad;
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proveedor = ConstruirProveedor(reader);
                            lista.Add(proveedor);
                        }
                    }
                }
            }
            return lista;

        }

        public void Agregar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string addQuery = @"INSERT INTO Proveedores (NombreProveedor, 
                                Direccion, CodigoPostal, PaisId, CiudadId,
                                Email, TelefonoFijo, TelefonoMovil)
                                VALUES (@Nombre, @Direccion,
                                @CodPostal, @PaisId, @CiudadId, @Email,
                                @TelefonoFijo, @TelefonoMovil); SELECT SCOPE_IDENTITY()";
                using (var cmd = new SqlCommand(addQuery, conn))
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                    cmd.Parameters["@Nombre"].Value = proveedor.NombreProveedor;

                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = proveedor.Direccion;

                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = proveedor.CodPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = proveedor.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = proveedor.CiudadId;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                    cmd.Parameters["@Email"].Value = proveedor.Email;

                    cmd.Parameters.Add("@TelefonoFijo", SqlDbType.NVarChar);
                    cmd.Parameters["@TelefonoFijo"].Value = proveedor.Telefono;



                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    proveedor.ProveedorId = id;
                }
            }

        }


        public Proveedor GetProveedorPorId(int ProveedorId)
        {
            Proveedor proveedor = null;
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                //TODO:Completar esto 
                string selectQuery = @"SELECT ProveedorId, NombreProveedor, Direccion, CodigoPostal,
                        TelefonoFijo, TelefonoMovil,
                        PaisId, CiudadId, Email 
                        FROM Proveedores WHERE ProveedorId=@ProveedorId";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    cmd.Parameters.Add("@ProveedorId", SqlDbType.Int);
                    cmd.Parameters["@ProveedorId"].Value = ProveedorId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            proveedor = ConstruirProveedor(reader);
                        }
                    }
                }
            }
            return proveedor;

        }

        private Proveedor ConstruirProveedor(SqlDataReader reader)
        {
            return new Proveedor()
            {
                ProveedorId = reader.GetInt32(0),
                NombreProveedor = reader.GetString(1),
                Direccion = reader.GetString(2),
                CodPostal = reader.GetString(3),
                PaisId = reader.GetInt32(4),
                CiudadId = reader.GetInt32(5),
                Telefono =reader[6]!=DBNull.Value? reader.GetString(6):string.Empty,
                Email = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty

            };
        }

        public List<Proveedor> GetProveedores(Pais paisFiltro, Ciudad ciudadFiltro)
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = @"SELECT ProveedorId, NombreProveedor, NombrePais, NombreCiudad 
                        FROM Proveedores INNER JOIN Paises ON Proveedores.PaisId=Paises.PaisId
                        INNER JOIN Ciudades ON Proveedores.CiudadId=Ciudades.CiudadId
                        WHERE Proveedores.PaisId=@PaisId AND Proveedores.CiudadId=@CiudadId
                        ORDER BY NombreProveedor";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = paisFiltro.PaisId;
                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = ciudadFiltro.CiudadId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proveedorDto = ConstruirProveedor(reader);
                            lista.Add(proveedorDto);
                        }
                    }
                }
            }
            return lista;

        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Productos WHERE ProveedorId=@ProveedorId";
                using (var comando = new SqlCommand(selectQuery, conn))
                {

                    comando.Parameters.Add("@ProveedorId", SqlDbType.Int);
                    comando.Parameters["@ProveedorId"].Value = proveedor.ProveedorId;


                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }
    }
}
