using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly string cadenaConexion;
        public RepositorioProductos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Producto producto)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO Productos (NombreProducto,  
                        ProveedorId, CategoriaId, PrecioUnitario, Stock, 
                        StockMinimo, Suspendido, Imagen) VALUES(@NombreProducto,
                        @ProveedorId, @CategoriaId, @PrecioUnitario, @Stock, 
                        @StockMinimo, @Suspendido, @Imagen); SELECT SCOPE_IDENTITY()";
                    using (var comando = new SqlCommand(insertQuery, conn))
                    {
                        comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar);
                        comando.Parameters["@NombreProducto"].Value = producto.NombreProducto;

                        comando.Parameters.Add("@ProveedorId", SqlDbType.Int);
                        comando.Parameters["@ProveedorId"].Value = producto.ProveedorId;

                        comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                        comando.Parameters["@CategoriaId"].Value = producto.CategoriaId;

                        comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
                        comando.Parameters["@PrecioUnitario"].Value = producto.PrecioUnitario;

                        comando.Parameters.Add("@Stock", SqlDbType.Int);
                        comando.Parameters["@Stock"].Value = producto.Stock;

                        comando.Parameters.Add("@StockMinimo", SqlDbType.Int);
                        comando.Parameters["@StockMinimo"].Value = producto.StockMinimo;


                        comando.Parameters.Add("@Suspendido", SqlDbType.Bit);
                        comando.Parameters["@Suspendido"].Value = producto.Suspendido;

                        comando.Parameters.Add("@Imagen", SqlDbType.NVarChar);
                        comando.Parameters["@Imagen"].Value = producto.Imagen;


                        int id = Convert.ToInt32(comando.ExecuteScalar());
                        producto.ProductoId = id;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int productoId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Productos WHERE ProductoId=@ProductoId";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@ProductoId", SqlDbType.Int);
                        comando.Parameters["@ProductoId"].Value = productoId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Editar(Producto producto)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string updateQuery = @"UPDATE Productos SET NombreProducto=@NombreProducto, 
                        ProveedorId=@ProveedorId, CategoriaId=@CategoriaId,
                        PrecioUnitario=@PrecioUnitario, Stock=@Stock, 
                        StockMinimo=@StockMinimo,
                        Suspendido=@Suspendido, Imagen=@Imagen WHERE ProductoId=@ProductoId";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar);
                        comando.Parameters["@NombreProducto"].Value = producto.NombreProducto;


                        comando.Parameters.Add("@ProveedorId", SqlDbType.Int);
                        comando.Parameters["@ProveedorId"].Value = producto.ProveedorId;

                        comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                        comando.Parameters["@CategoriaId"].Value = producto.CategoriaId;

                        comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
                        comando.Parameters["@PrecioUnitario"].Value = producto.PrecioUnitario;

                        comando.Parameters.Add("@Stock", SqlDbType.Int);
                        comando.Parameters["@Stock"].Value = producto.Stock;

                        comando.Parameters.Add("@StockMinimo", SqlDbType.Int);
                        comando.Parameters["@StockMinimo"].Value = producto.StockMinimo;

                        comando.Parameters.Add("@Suspendido", SqlDbType.Bit);
                        comando.Parameters["@Suspendido"].Value = producto.Suspendido;

                        comando.Parameters.Add("@Imagen", SqlDbType.NVarChar);
                        comando.Parameters["@Imagen"].Value = producto.Imagen;

                        comando.Parameters.Add("@ProductoId", SqlDbType.Int);
                        comando.Parameters["@ProductoId"].Value = producto.ProductoId;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Producto> GetProductos()
        {
            try
            {
                List<Producto> lista = new List<Producto>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT * FROM Productos ORDER BY NombreProducto";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var producto = ConstruirProducto(reader);
                                lista.Add(producto);
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

        public int GetCantidad()
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Productos";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (producto.ProductoId == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM Productos WHERE NombreProducto=@NombreProducto";

                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM Productos WHERE NombreProducto=@NombreProducto AND ProductoId<>@ProductoId";

                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar);
                        comando.Parameters["@NombreProducto"].Value = producto.NombreProducto;

                        if (producto.ProductoId != 0)
                        {
                            comando.Parameters.Add("@ProductoId", SqlDbType.Int);
                            comando.Parameters["@ProductoId"].Value = producto.ProductoId;

                        }

                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Producto> GetProductosPorPagina(int cantidad, int pagina)
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT * FROM Productos 
                        ORDER BY NombreProducto
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
                                var productoDto = ConstruirProducto(reader);
                                lista.Add(productoDto);
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

        private Producto ConstruirProducto(SqlDataReader reader)
        {
            return new Producto
            {
                ProductoId = reader.GetInt32(0),
                NombreProducto = reader.GetString(1),
                ProveedorId = reader.GetInt32(2),
                CategoriaId = reader.GetInt32(3),
                PrecioUnitario = reader.GetDecimal(4),
                Stock = reader.GetInt32(5),
                StockMinimo = reader.GetInt32(6),
                Suspendido = reader.GetBoolean(7),
                Imagen = reader[8] == DBNull.Value ? string.Empty : reader.GetString(8)
            };
        }


        public Producto GetProductoPorId(int productoId)
        {
            try
            {
                Producto producto = null;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT *
                        FROM Productos WHERE ProductoId=@ProductoId";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@ProductoId", SqlDbType.Int);
                        comando.Parameters["@ProductoId"].Value = productoId;
                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                producto = ConstruirProducto(reader);
                            }
                        }
                    }
                }
                return producto;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EstaRelacionado(Producto producto)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT(SELECT COUNT(*) FROM DetalleVentas WHERE ProductoId=@ProductoId)
                                    + (SELECT COUNT(*) FROM DetalleVentas WHERE ProductoId=@ProductoId)";
                using (var comando = new SqlCommand(selectQuery, conn))
                {

                    comando.Parameters.Add("@ProductoId", SqlDbType.Int);
                    comando.Parameters["@ProductoId"].Value = producto.ProductoId;


                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }
    }
}
