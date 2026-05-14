using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Usuario;

public class UsuarioResponseDTOs{
    public int Id {get;set;}
    public string Nombre {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;
    public UsuarioRol Rol {get;set;}
}