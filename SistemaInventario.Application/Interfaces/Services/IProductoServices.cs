using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Producto;

namespace SistemaInventario.Application.Interfaces.Services;

public interface IProductoServices{
    public Task<List<ProductoResponseDTOs>> ObtenerTodos();
    public Task<ProductoResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateProductoDTOs createProductoDTOs);
    public Task Actualizar(int Id,UpdateProductoDTOs updateProductoDTOs);
    public Task Eliminar(int Id);
}