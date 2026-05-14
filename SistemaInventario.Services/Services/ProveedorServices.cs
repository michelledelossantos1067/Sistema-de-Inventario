using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Proveedor;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;

public class ProveedorServices : IProveedorServices{
    private readonly IProveedorRepositories _proveedorRepositories;

    public ProveedorServices(IProveedorRepositories proveedorRepositories){
        _proveedorRepositories = proveedorRepositories;
    }
    public async Task<List<ProveedorResponseDTOs>> ObtenerTodos(){
        var proveedor = await _proveedorRepositories.ObtenerTodos();
        return proveedor.Select(c => new ProveedorResponseDTOs{
            Nombre = c.Nombre,
            RNC = c.RNC,
            Telefono = c.Telefono,
            Direccion = c.Direccion,
            Email = c.Email,
        }).ToList();
    }
    public async Task<ProveedorResponseDTOs?> ObtenerPorId(int Id){
        var proveedor = await _proveedorRepositories.ObtenerPorId(Id);
        if(proveedor == null){
            return null;
        };
        var proveedorDTOs = new ProveedorResponseDTOs{
            Id = proveedor.Id,
            Nombre = proveedor.Nombre,
            RNC = proveedor.RNC,
            Telefono = proveedor.Telefono,
            Direccion = proveedor.Direccion,
            Email = proveedor.Email
        };
        return proveedorDTOs;
    }
    public async Task Crear(CreateProveedorDTOs createProveedorDTOs){
        var proveedorDTOs = new Proveedor{
            Nombre = createProveedorDTOs.Nombre,
            RNC = createProveedorDTOs.RNC,
            Telefono = createProveedorDTOs.Telefono,
            Direccion = createProveedorDTOs.Direccion,
            Email = createProveedorDTOs.Email
        };
        await _proveedorRepositories.Crear(proveedorDTOs);

    }
    public async Task Actualizar(int Id, UpdateProveedorDTOs updateProveedorDTOs){
        var proveedores = await _proveedorRepositories.ObtenerPorId(Id);
        if(proveedores == null){
            throw new Exception("El proveedor no existe.");
        };
        proveedores.Nombre = updateProveedorDTOs.Nombre;
        proveedores.RNC = updateProveedorDTOs.RNC;
        proveedores.Telefono = updateProveedorDTOs.Telefono;
        proveedores.Direccion = updateProveedorDTOs.Direccion;
        proveedores.Email = updateProveedorDTOs.Email;
        
        await _proveedorRepositories.Actualizar(Id,proveedores);
    }
    public async Task Eliminar(int Id){
        var proveedor = await _proveedorRepositories.ObtenerPorId(Id);
        if (proveedor == null){
            throw new Exception("El proveedor no existe.");
        };
        await _proveedorRepositories.Eliminar(Id);
    }
    
}