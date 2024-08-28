using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Intefaces
{
    public  interface IProveedorServicio
    {
        IEnumerable<IProveedorServicio> ObtenerProveedores();
        void AgregarProveedor(Proveedor proveedor);
        void EliminarProveedor(int id); 
        void ActualizarProveedor(Proveedor proveedor); 
    }

    public class ProveedorServicio : IProveedorServicio
    {
        private readonly IProveedorRepositorio _repositorio;

        public ProveedorServicio(IProveedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Proveedor> ObtenerProveedores()
        {
            return _repositorio.ListarProveedores();
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            _repositorio.IngresarProveedor(proveedor);
        }

        public void EliminarProveedor(int id)
        {
            _repositorio.BorrarProveedor(id);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _repositorio.ModificarProveedor(proveedor);
        }

        IEnumerable<IProveedorServicio> IProveedorServicio.ObtenerProveedores()
        {
            throw new NotImplementedException();
        }
    }
}
