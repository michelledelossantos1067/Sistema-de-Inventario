using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Movimiento;

public class CreateMovimientoDTOs{
    public DateTime Fecha {get;set;}
    public TipoMovimiento Tipo {get;set;}
    public string Motivo {get;set;} = string.Empty;
    public int Cantidad {get;set;}

    public int ProductoId { get; set; }
    public int AlmacenId {get;set;}
    public int UsuarioId {get;set;}
}