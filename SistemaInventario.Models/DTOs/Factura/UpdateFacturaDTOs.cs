using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Factura;

public class UpdateFacturaDTOs{
    public int Id {get;set;}
    public DateTime FechaLimite {get;set;}
    public Fatura_Estado Estado {get;set;}
    
    public int UsuarioId {get;set;}
    public int ProveedorId {get;set;}
}