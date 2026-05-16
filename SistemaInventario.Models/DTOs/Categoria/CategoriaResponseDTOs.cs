
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.DTOs.Categoria;

public class CategoriaResponseDTOs{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion {get;set;}
}
