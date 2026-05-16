
using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.DTOs.Categoria;

public class CreateCategoriaDTOs
{
    [Required]
    [MaxLength(1,ErrorMessage = "El nombre es requerido.")]
    public string Nombre { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Descripcion {get;set;} = string.Empty;
}
