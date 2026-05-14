using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.DetalleFactura;

public class UpdateDetalleFacturaDTOs{
    public int Id {get;set;}
    public int Cantidad {get;set;}

    public int FacturaId {get;set;}
    public int ProductoId {get;set;}
}

