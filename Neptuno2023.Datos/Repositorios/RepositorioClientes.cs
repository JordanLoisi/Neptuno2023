using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private string cadenaConexion;
        public RepositorioClientes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Borrar(int clienteId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Clientes WHERE ClienteId=@ClienteId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                    comando.Parameters["@ClienteId"].Value = clienteId;

                    comando.ExecuteNonQuery();
                }
            }

        }

        public void Editar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Clientes SET NombreCliente=@NombreCliente,
                                Direccion=@Direccion, 
                                CodPostal=@CodPostal, PaisId=@PaisId, 
                                CiudadId=@CiudadId,  
                                TelFijo=@TelFijo, TelMovil=@TelMovil 
                                WHERE ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@NombreCliente", SqlDbType.NVarChar);
                    cmd.Parameters["@NombreCliente"].Value = cliente.NombreCliente;


                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = cliente.Direccion;

                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = cliente.CodPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = cliente.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = cliente.CiudadId;


                    cmd.Parameters.Add("@TelefonoFijo", SqlDbType.NVarChar);
                    cmd.Parameters["@TelFijo"].Value = cliente.TelFijo;

                    cmd.Parameters.Add("@TelMovil", SqlDbType.NVarChar);
                    cmd.Parameters["@TeMovil"].Value = cliente.TelMovil;



                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                    cmd.Parameters["@ClienteId"].Value = cliente.ClienteId;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool Existe(Cliente cliente)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery;
                if (cliente.ClienteId == 0)
                {
                    selectQuery = "SELECT COUNT(*) FROM Clientes WHERE NombreCliente=@NombreCliente";

                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Clientes WHERE NombreCliente=@NombreCliente AND ClienteId=@ClienteId";

                }
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                    comando.Parameters["@Nombre"].Value = cliente.NombreCliente;


                    if (cliente.ClienteId != 0)
                    {
                        comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                        comando.Parameters["@ClienteId"].Value = cliente.ClienteId;

                    }

                    cantidad = (int)comando.ExecuteScalar();
                }
                return cantidad > 0;
            }
        }


        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Clientes";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad;

        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string selectQuery = @"SELECT * 
                        FROM Clientes ORDER BY NombreCliente";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = ConstruirCliente(reader);
                            lista.Add(cliente);
                        }
                    }
                }
            }
            return lista;
        }

        public List<Cliente> GetClientesPorPagina(int cantidad, int pagina)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT * 
                        FROM Clientes 
                        ORDER BY NombreCliente
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
                                var cliente = ConstruirCliente(reader);
                                lista.Add(cliente);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Agregar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string addQuery = @"INSERT INTO Clientes (NombreCliente, 
                                Direccion, CodPostal, PaisId, CiudadId,
                                TelFijo, TelMovil)
                                VALUES (@NombreCliente, @Direccion,
                                @CodPostal, @PaisId, @CiudadId, @TelFijo, @TelMovil); SELECT SCOPE_IDENTITY()";
                using (var cmd = new SqlCommand(addQuery, conn))
                {
                    cmd.Parameters.Add("@NombreCliente", SqlDbType.NVarChar);
                    cmd.Parameters["@NombreCliente"].Value = cliente.NombreCliente;


                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = cliente.Direccion;

                    cmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodPostal"].Value = cliente.CodPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = cliente.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = cliente.CiudadId;


                    cmd.Parameters.Add("@TelefonoFijo", SqlDbType.NVarChar);
                    cmd.Parameters["@TelFijo"].Value = cliente.TelFijo;

                    cmd.Parameters.Add("@TelMovil", SqlDbType.NVarChar);
                    cmd.Parameters["@TeMovil"].Value = cliente.TelMovil;


                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    cliente.ClienteId = id;
                }
            }

        }


        public Cliente GetClientePorId(int clienteId)
        {
            Cliente cliente = null;
            using (var con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                //TODO:Completar esto 
                string selectQuery = @"SELECT ClienteId, NombreCliente, Direccion, CodPostal,
                        PaisId, CiudadId, TelFijo, TelMovil
                        FROM Clientes WHERE ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(selectQuery, con))
                {
                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                    cmd.Parameters["@ClienteId"].Value = clienteId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            cliente = ConstruirCliente(reader);
                        }
                    }
                }
            }
            return cliente;

        }

        private Cliente ConstruirCliente(SqlDataReader reader)
        {
            return new Cliente()
            {
                ClienteId = reader.GetInt32(0),
                NombreCliente = reader.GetString(1),
                Direccion = reader.GetString(2),
                CodPostal = reader[3] != DBNull.Value ? reader.GetString(3) : string.Empty,

                PaisId = reader.GetInt32(4),
                CiudadId = reader.GetInt32(5),
                TelFijo = reader[6] != DBNull.Value ? reader.GetString(6) : string.Empty,
                TelMovil = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty


            };
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Ventas WHERE ClienteId=@ClienteId";
                using (var comando = new SqlCommand(selectQuery, conn))
                {

                    comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                    comando.Parameters["@ClienteId"].Value = cliente.ClienteId;


                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }
    }
}
