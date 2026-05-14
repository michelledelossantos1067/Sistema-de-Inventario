using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Usuario;

public class CreateUsuarioDTOs{
    public string Nombre {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
    public UsuarioRol Rol {get;set;}
}