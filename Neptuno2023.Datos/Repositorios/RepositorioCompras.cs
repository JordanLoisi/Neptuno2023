using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Dto;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioCompras : IRepositorioCompras
    {
        private readonly string cadenaConexion;
        public RepositorioCompras()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public int GetCantidad()
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Compras";
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

        public List<ComprasDto> GetComprasDto()
        {
            try
            {
                List<ComprasDto> lista = new List<ComprasDto>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT c.ComprasId,p.ProveedoresId,c.FechaCompras,c.Total FROM Compras c INNER JOIN Proveedores p ON p.Proveedores=c.Proveedores ORDER BY ComprasId";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var compras = ConstruirComprasDTO(reader);
                                lista.Add((ComprasDto)compras);
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

        private object ConstruirComprasDTO(SqlDataReader reader)
        {
            return new ComprasDto()
            {
                ComprasId = reader.GetInt32(0),
                FechaCompra = reader.GetDateTime(1),
                NombreProveedor = reader.GetString(2),
                Total = reader.GetDecimal(3),


            };
        }

        public List<ComprasDto> GetComprasPorPagina(int cantidad, int pagina)
        {
            List<ComprasDto> lista = new List<ComprasDto>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT c.ComprasId,p.ProveedoresId,c.FechaCompras,c.Total FROM Compras c INNER JOIN Proveedores p ON p.Proveedores=c.Proveedores ORDER BY ComprasId              
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
                                var compras = ConstruirComprasDTO(reader);
                                lista.Add((ComprasDto)compras);
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
        public ComprasDto GetComprasPorId(int comprasId)
        {
            ComprasDto compras = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT c.ComprasId,p.ProveedoresId,c.FechaCompras,c.Total FROM Compras c INNER JOIN Proveedores p ON p.Proveedores=c.Proveedores   WHERE VentaId=@VentaId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@ComprasId", SqlDbType.Int);
                    cmd.Parameters["@ComprasId"].Value = comprasId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            compras = (ComprasDto)ConstruirComprasDTO(reader);
                        }
                    }
                }
            }
            return compras;


        }
    }
}


        
    
