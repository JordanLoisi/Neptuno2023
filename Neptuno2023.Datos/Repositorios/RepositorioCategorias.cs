using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string cadenaConexion;
        public RepositorioCategorias()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }


        public void Agregar(Categoria categoria)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Categorias (NombreCategoria, Descripcion) VALUES(@NombreCategoria, @Descripcion); SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                    comando.Parameters["@Descripcion"].Value = categoria.Descripcion;

                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    categoria.CategoriaId = id;
                }
            }
        }
        public void Borrar(int categoriaId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Categorias WHERE CategoriaId=@CategoriaId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    comando.Parameters["@CategoriaId"].Value = categoriaId;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void Editar(Categoria categoria)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = "UPDATE Categorias SET NombreCategoria=@NombreCategoria WHERE CategoriaId=@CategoriaId";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@NombreCategoria", SqlDbType.NChar);
                    cmd.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                    cmd.ExecuteNonQuery();
                }
            }

        }
        public List<Categoria> GetCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias ORDER BY NombreCategoria";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = ConstruirCategoria(reader);
                            lista.Add(categoria);
                        }
                    }
                }
            }
            return lista;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Categorias";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad;

        }

        public bool Existe(Categoria categoria)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery;
                if (categoria.CategoriaId == 0)
                {
                    selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria";

                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria AND CategoriaId<>@CategoriaId";

                }
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    if (categoria.CategoriaId != 0)
                    {
                        comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                        comando.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                    }

                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }

        public List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            List<Categoria> lista = new List<Categoria>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = @"ccccccc
                    ORDER BY NombreCategoria
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
                            var categoria = ConstruirCategoria(reader);
                            lista.Add(categoria);
                        }
                    }
                }
            }
            return lista;
        }

        private Categoria ConstruirCategoria(SqlDataReader reader)
        {
            return new Categoria()
            {
                CategoriaId = reader.GetInt32(0),
                NombreCategoria = reader.GetString(1),
                Descripcion = reader[2] != DBNull.Value ? reader.GetString(2) : string.Empty
            };
        }

        public bool EstaRelacionada(Categoria categoria)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Productos WHERE CategoriaId=@CategoriaId";
                using (var comando = new SqlCommand(selectQuery, conn))
                {

                    comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    comando.Parameters["@CategoriaId"].Value = categoria.CategoriaId;


                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }

        public Categoria GetCategoriaPorId(int categoriaId)
        {
            Categoria categoria = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT CategoriaId, NombreCategoria, Descripcion FROM Categorias WHERE CategoriaId=@CategoriaId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaId"].Value = categoriaId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            categoria = ConstruirCategoria(reader);
                        }
                    }
                }
            }
            return categoria;
        }
    }
}