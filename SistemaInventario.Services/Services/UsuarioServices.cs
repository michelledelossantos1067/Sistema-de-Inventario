using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Usuario;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;
public class UsuarioServices : IUsuarioServices{
    private readonly IUsuarioRepositories _usuarioRepositories;

    public UsuarioServices(IUsuarioRepositories usuarioRepositories){
        _usuarioRepositories = usuarioRepositories;
    }

    public async Task<List<UsuarioResponseDTOs>> ObtenerTodos(){
        var usuario = await _usuarioRepositories.ObtenerTodos();
        return usuario.Select(c => new UsuarioResponseDTOs{
            Id = c.Id,
            Nombre = c.Nombre,
            Email = c.Email,
            Rol = c.Rol
        }).ToList();
    }
    public async Task<UsuarioResponseDTOs?> ObtenerPorId(int Id){
        var usuario = await _usuarioRepositories.ObtenerPorId(Id);
        if (usuario == null){
            return null;
        };
        var usuarioDTOs = new UsuarioResponseDTOs{
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Rol = usuario.Rol
        };
        return usuarioDTOs;
    }
    public async Task Crear(CreateUsuarioDTOs createUsuarioDTOs){
        var usuarios = new Usuario{
            Nombre = createUsuarioDTOs.Nombre,
            Email = createUsuarioDTOs.Email,
            Password = createUsuarioDTOs.Password,
            Rol = createUsuarioDTOs.Rol
        };
        await _usuarioRepositories.Crear(usuarios);
    }
    public async Task Actualizar(int Id,UpdateUsuarioDTOs updateUsuarioDTOs){
        var usuarios = await _usuarioRepositories.ObtenerPorId(Id);
        if(usuarios == null){
            throw new Exception("No existe este usuario.");
        };
        usuarios.Nombre = updateUsuarioDTOs.Nombre;
        usuarios.Email = updateUsuarioDTOs.Email;
        usuarios.Password = updateUsuarioDTOs.Password;

        await _usuarioRepositories.Actualizar(Id,usuarios);
    }
    public async Task Eliminar(int Id){
        var usuario = await _usuarioRepositories.ObtenerPorId(Id);
        if(usuario == null){
            throw new Exception("No existe este usuario.");
        };
        await _usuarioRepositories.Eliminar(Id);
    }
}
