using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.DetalleFactura;

public class DetalleFacturaResponseDTOs{
    public int Id {get;set;}
    public int Cantidad {get;set;}
    public decimal PrecioUnitario {get;set;}

    public int FacturaId {get;set;}
    public int ProductoId {get;set;}
}

