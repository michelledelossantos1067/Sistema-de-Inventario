using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Movimiento;
namespace SistemaInventario.Application.Interfaces.Services;

public interface IMovimientoServices{
    public Task<List<MovimientoResponseDTOs>> ObtenerTodos();
    public Task<MovimientoResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateMovimientoDTOs createMovimientoDTOs);
    public Task Eliminar(int Id);
    
}