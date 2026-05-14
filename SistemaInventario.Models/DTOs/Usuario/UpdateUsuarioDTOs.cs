using SistemaInventario.Models.Enums;
namespace SistemaInventario.Models.DTOs.Usuario;

public class UpdateUsuarioDTOs{
    public int Id {get;set;}
    public string Nombre {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
}