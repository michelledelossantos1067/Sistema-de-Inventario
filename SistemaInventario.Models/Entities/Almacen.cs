using SistemaInventario.Models.Entities;

namespace SistemaInventario.Models.Entities;
public class Almacen
{
    public int Id { get; set; }
    public string? Nombre { get; set;} = string.Empty;
    public string? Empresa {get;set;} = string.Empty;
    public string? Direccion {get;set;} = string.Empty;
}
