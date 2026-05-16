using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.Entities;

public class Proveedor{
    public int Id {get;set;}
    public string Nombre { get; set; } = string.Empty;
    public string RNC {get;set;} = string.Empty;
    public string Telefono {get;set;} = string.Empty;
    public string Direccion {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;

}
