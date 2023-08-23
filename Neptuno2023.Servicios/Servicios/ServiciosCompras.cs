using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Dto;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosCompras : IServiciosCompras
    {
        private readonly RepositorioCompras _repositorioCompras;
        public ServiciosCompras()
        {
            _repositorioCompras = new RepositorioCompras();
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorioCompras.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComprasDto> GetComprasDTO()
        {
            try
            {
                return _repositorioCompras.GetComprasDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComprasDto> GetComprasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorioCompras.GetComprasPorPagina(cantidad, pagina);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

        
    
