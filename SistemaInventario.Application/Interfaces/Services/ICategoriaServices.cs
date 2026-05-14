using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Categoria;

namespace SistemaInventario.Application.Interfaces.Services;

public interface ICategoriaServices{
    public Task<List<CategoriaResponseDTOs>> ObtenerTodos();
    public Task<CategoriaResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateCategoriaDTOs createCategoriaDTOs);
    public Task Actualizar(int Id,UpdateCategoriaDTOs updateCategoriaDTOs);
    public Task Eliminar(int Id);
}