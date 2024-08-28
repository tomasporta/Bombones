﻿using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosProveedores
    {
        void Borrar(int ciudadId);
        bool EstaRelacionado(int ciudadId);
        bool Existe(Ciudad ciudad);
        int GetCantidad(Pais? paisSeleccionado=null, ProvinciaEstado? provSeleccionada=null);
        Ciudad? GetCiudadPorId(int ciudadId);
        List<CiudadListDto> GetLista(int? currentPage, int? pageSize);
        List<ProveedorListDto> GetLista(int? currentPage, decimal pageSize);
        List<Ciudad> GetListaCombo(Pais paisSeleccionado, ProvinciaEstado provinciaEstado);
        int GetPaginaPorRegistro(string nombreCiudad, int pageSize);
        void Guardar(Ciudad ciudad);
        void Guardar(Proveedor proveedor);
    }
}
