using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.DetalleFactura;

public class CreateDetalleFacturaDTOs{
    public int Cantidad {get;set;}
    public decimal PrecioUnitario {get;set;}

    public int FacturaId {get;set;}
    public int ProductoId {get;set;}
}
