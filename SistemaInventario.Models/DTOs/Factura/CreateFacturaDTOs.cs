using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Factura;

public class CreateFacturaDTOs{
    public DateTime FechaFactura {get;set;}
    public DateTime FechaLimite {get;set;}
    public Fatura_Estado Estado {get;set;}

    public int UsuarioId {get;set;}
    public int ProveedorId {get;set;}
}