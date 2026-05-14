using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Factura;

public class FacturaResponseDTOs{
    public int Id {get;set;}
    public decimal Total {get;set;}

    public int UsuarioId {get;set;}
    public int ProveedorId {get;set;}
}