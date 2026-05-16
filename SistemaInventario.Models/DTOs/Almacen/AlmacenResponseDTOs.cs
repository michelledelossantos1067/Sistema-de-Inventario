
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.DTOs.Almacen;

public class AlmacenResponseDTOs{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Empresa { get; set; }
    public string? Direccion {get;set;}
}