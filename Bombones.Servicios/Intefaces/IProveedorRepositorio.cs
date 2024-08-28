using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Intefaces
{
   public  interface IProveedorRepositorio
    {
        IEnumerable<Proveedor> ListarProveedores();
        void IngresarProveedor(Proveedor proveedor);
        void BorrarProveedor(int id); // Opcional
        void ModificarProveedor(Proveedor proveedor); // Opcional
    }

    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly List<Proveedor> _proveedores = new List<Proveedor>();

        public IEnumerable<Proveedor> ListarProveedores()
        {
            return _proveedores;
        }

        public void IngresarProveedor(Proveedor proveedor)
        {
            _proveedores.Add(proveedor);
        }

        public void BorrarProveedor(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                _proveedores.Remove(proveedor);
            }
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            var proveedorExistente = _proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (proveedorExistente != null)
            {
                proveedorExistente.NombreProveedor = proveedor.NombreProveedor;
                proveedorExistente.Direccion = proveedor.Direccion;
                proveedorExistente.Telefono = proveedor.Telefono;
                proveedorExistente.Email = proveedor.Email;
            }
        }
    }
}
