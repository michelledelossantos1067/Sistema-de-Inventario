using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Movimiento;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;
public class MovimientoServices : IMovimientoServices{
    private readonly IMovimientoRepositories _movimientoRepositories;

    public MovimientoServices(IMovimientoRepositories movimientoRepositories){
        _movimientoRepositories = movimientoRepositories;
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
            ProductoId = createMovimientoDTOs.ProductoId,
            UsuarioId = createMovimientoDTOs.UsuarioId
        };
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
