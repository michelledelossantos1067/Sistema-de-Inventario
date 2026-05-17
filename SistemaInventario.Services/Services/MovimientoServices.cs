using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Movimiento;
using SistemaInventario.Models.Entities;
using SistemaInventario.Models.Enums;

namespace SistemaInventario.Services.Services;
public class MovimientoServices : IMovimientoServices{
    private readonly IMovimientoRepositories _movimientoRepositories;
    private readonly IInventarioAlmacenRepositories _inventarioAlmacenRepositories;

    public MovimientoServices(IMovimientoRepositories movimientoRepositories,IInventarioAlmacenRepositories inventarioAlmacenRepositories){
        _movimientoRepositories = movimientoRepositories;
        _inventarioAlmacenRepositories = inventarioAlmacenRepositories;
    }
    public async Task<List<MovimientoResponseDTOs>> ObtenerTodos(){
        var movimiento = await _movimientoRepositories.ObtenerTodos();
        return movimiento.Select(c => new MovimientoResponseDTOs{
            Fecha = c.Fecha,
            Tipo = c.Tipo,
            Motivo = c.Motivo,
            Cantidad = c.Cantidad,
            ProductoId = c.ProductoId,
            UsuarioId = c.UsuarioId
        }).ToList();
    }
    public async Task<MovimientoResponseDTOs?> ObtenerPorId(int Id){
        var movimiento = await _movimientoRepositories.ObtenerPorId(Id);
        if (movimiento == null){
            return null;
        };
        var movimientoDTOs = new MovimientoResponseDTOs{
            Id = movimiento.Id,
            Fecha = movimiento.Fecha,
            Tipo = movimiento.Tipo,
            Motivo = movimiento.Motivo,
            Cantidad = movimiento.Cantidad,
            ProductoId = movimiento.ProductoId,
            UsuarioId = movimiento.UsuarioId,
        };
        
        return movimientoDTOs;
    }
    public async Task Crear(CreateMovimientoDTOs createMovimientoDTOs){
        var movimientoDTOs = new Movimiento{
            Fecha = createMovimientoDTOs.Fecha,
            Tipo = createMovimientoDTOs.Tipo,
            Motivo = createMovimientoDTOs.Motivo,
            Cantidad = createMovimientoDTOs.Cantidad,
            AlmacenId = createMovimientoDTOs.AlmacenId,
            ProductoId = createMovimientoDTOs.ProductoId,
            UsuarioId = createMovimientoDTOs.UsuarioId
        };
        if (createMovimientoDTOs.Tipo == TipoMovimiento.Entrada)
        {
            var inventario = await _inventarioAlmacenRepositories.ObtenerPorProductoYAlmacen(createMovimientoDTOs.ProductoId, createMovimientoDTOs.AlmacenId);
            if (inventario == null)
            {

                var NuevoInventario = new InventarioAlmacen
                {
                    ProductoId = createMovimientoDTOs.ProductoId,
                    AlmacenId= createMovimientoDTOs.AlmacenId,
                    Stock = createMovimientoDTOs.Cantidad,
                    StockMinimo = 0
                };
            await _inventarioAlmacenRepositories.Crear(NuevoInventario);
            }else
            {
                if (inventario != null)
                {
                    inventario.Stock += createMovimientoDTOs.Cantidad;
                    await _inventarioAlmacenRepositories.Actualizar(inventario.Id,inventario);
                }
            }
        }
        else
        {
            var inventario = await _inventarioAlmacenRepositories.ObtenerPorProductoYAlmacen(createMovimientoDTOs.ProductoId, createMovimientoDTOs.AlmacenId);
            if (inventario == null)
            {
                throw new Exception("No hay stock");
            }
            if (inventario.Stock < createMovimientoDTOs.Cantidad)
            {
                throw new Exception("Stock insuficiente.");
            }
            else
            {
                inventario.Stock -= createMovimientoDTOs.Cantidad;
                await _inventarioAlmacenRepositories.Actualizar(inventario.Id,inventario);
            }
        }
        await _movimientoRepositories.Crear(movimientoDTOs);
    }
    public async Task Eliminar(int Id){
        var movimiento = await _movimientoRepositories.ObtenerPorId(Id);
        if (movimiento == null){
            throw new Exception("El movimiento no existe.");
        };
        await _movimientoRepositories.Eliminar(Id);
    }
}
