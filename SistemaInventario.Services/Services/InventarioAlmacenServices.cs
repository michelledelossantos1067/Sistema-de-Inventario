using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.InventarioAlmacen;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Services.Services;
public class InventarioAlmacenServices : IInventarioAlmacenServices{
    private readonly IInventarioAlmacenRepositories _inventarioAlmacenRepositories;

    public InventarioAlmacenServices(IInventarioAlmacenRepositories inventarioAlmacenRepositories){
        _inventarioAlmacenRepositories = inventarioAlmacenRepositories;
    }
    public async Task<List<InventarioAlmacenResponseDTOs>> ObtenerTodos(){
        var inventarioAlmacen = await _inventarioAlmacenRepositories.ObtenerTodos();
        return inventarioAlmacen.Select(c => new InventarioAlmacenResponseDTOs{
            ProductoId = c.ProductoId,
            AlmacenId = c.AlmacenId,
            Stock = c.Stock,
            StockMinimo = c.StockMinimo

        }).ToList();
    }
    public async Task<InventarioAlmacenResponseDTOs?> ObtenerPorId(int Id){
        var inventarioAlmacen = await _inventarioAlmacenRepositories.ObtenerPorId(Id);
        if (inventarioAlmacen == null){
            return null;
        };
        var inventarioAlmacenDTOs = new InventarioAlmacenResponseDTOs{
            Id = inventarioAlmacen.Id,
            ProductoId = inventarioAlmacen.ProductoId,
            AlmacenId = inventarioAlmacen.AlmacenId,
            Stock = inventarioAlmacen.Stock,
            StockMinimo = inventarioAlmacen.StockMinimo
        };
        
        return inventarioAlmacenDTOs;
    }
    public async Task Crear(CreateInventarioAlmacenDTOs createInventarioAlmacenDTOs){
        var inventarioAlmacenDTOs = new InventarioAlmacen{
            ProductoId = createInventarioAlmacenDTOs.ProductoId,
            AlmacenId = createInventarioAlmacenDTOs.AlmacenId,
            Stock = createInventarioAlmacenDTOs.Stock,
            StockMinimo = createInventarioAlmacenDTOs.StockMinimo
        };
        await _inventarioAlmacenRepositories.Crear(inventarioAlmacenDTOs);
    }
    public async Task Actualizar(int Id, UpdateInventarioAlmacenDTOs updateInventarioAlmacenDTOs){
        var inventarioAlmacen = await _inventarioAlmacenRepositories.ObtenerPorId(Id);
        if(inventarioAlmacen == null){
            throw new Exception("El inventario del almacen no existe.");
        };
        inventarioAlmacen.ProductoId = updateInventarioAlmacenDTOs.ProductoId;
        inventarioAlmacen.AlmacenId = updateInventarioAlmacenDTOs.AlmacenId;
        inventarioAlmacen.Stock = updateInventarioAlmacenDTOs.Stock;
        inventarioAlmacen.StockMinimo = updateInventarioAlmacenDTOs.StockMinimo;

        await _inventarioAlmacenRepositories.Actualizar(Id,inventarioAlmacen);
    }
    
    public async Task Eliminar(int Id){
        var inventarioAlmacen = await _inventarioAlmacenRepositories.ObtenerPorId(Id);
        if(inventarioAlmacen == null){
            throw new Exception("El inventario del almacen no existe.");
        };
        await _inventarioAlmacenRepositories.Eliminar(Id);
    }
}
