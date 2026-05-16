
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.DTOs.Categoria;

public class UpdateCategoriaDTOs{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Descripcion {get;set;} = string.Empty;
}
