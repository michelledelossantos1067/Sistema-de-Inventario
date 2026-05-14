using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Usuario;
namespace SistemaInventario.Application.Interfaces.Services;

public interface IUsuarioServices{
    public Task<List<UsuarioResponseDTOs>> ObtenerTodos();
    public Task<UsuarioResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateUsuarioDTOs createUsuarioDTOs);
    public Task Actualizar(int Id,UpdateUsuarioDTOs updateUsuarioDTOs);
    public Task Eliminar(int Id);
    
}