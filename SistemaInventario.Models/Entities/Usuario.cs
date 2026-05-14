using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.Entities;

public class Usuario{
    public int Id {get;set;}
    public string Nombre {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
    public UsuarioRol Rol {get;set;}
}