using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Almacen;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Services.Services;
public class AlmacenServices : IAlmacenServices{
    private readonly IAlmacenRepositories _almacenRepositories;

    public AlmacenServices(IAlmacenRepositories almacenRepositories){
        _almacenRepositories = almacenRepositories;
    }
    public async Task<List<AlmacenResponseDTOs>> ObtenerTodos(){
        var almacen = await _almacenRepositories.ObtenerTodos();
        return almacen.Select(c => new AlmacenResponseDTOs{
            Nombre = c.Nombre,
            Empresa = c.Empresa,
            Direccion = c.Direccion

        }).ToList();
    }
    public async Task<AlmacenResponseDTOs?> ObtenerPorId(int Id){
        var almacen = await _almacenRepositories.ObtenerPorId(Id);
        if (almacen == null){
            return null;
        };
        var almacenDTOs = new AlmacenResponseDTOs{
            Id = almacen.Id,
            Nombre = almacen.Nombre,
            Empresa = almacen.Empresa,
            Direccion = almacen.Direccion
        };
        
        return almacenDTOs;
    }
    public async Task Crear(CreateAlmacenDTOs createAlmacenDTOs){
        var almacenDTOs = new Almacen{
            Nombre = createAlmacenDTOs.Nombre,
            Empresa = createAlmacenDTOs.Empresa,
            Direccion = createAlmacenDTOs.Direccion
        };
        await _almacenRepositories.Crear(almacenDTOs);
    }
    public async Task Actualizar(int Id, UpdateAlmacenDTOs updateAlmacenDTOs){
        var almacen = await _almacenRepositories.ObtenerPorId(Id);
        if(almacen == null){
            throw new Exception("El almacen no existe.");
        };
        almacen.Nombre = updateAlmacenDTOs.Nombre;
        almacen.Empresa = updateAlmacenDTOs.Empresa;
        almacen.Direccion = updateAlmacenDTOs.Direccion;
        
        await _almacenRepositories.Actualizar(Id,almacen);
    }
    
    public async Task Eliminar(int Id){
        var almacen = await _almacenRepositories.ObtenerPorId(Id);
        if(almacen == null){
            throw new Exception("El almacen no existe.");
        };
        await _almacenRepositories.Eliminar(Id);
    }
}
