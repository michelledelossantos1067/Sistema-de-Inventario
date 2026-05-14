using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.Entities;

public class Factura{
    public int Id {get;set;}
    public decimal Total {get;set;}
    public DateTime FechaFactura {get;set;}
    public DateTime FechaLimite {get;set;}
    public Fatura_Estado Estado {get;set;}

    public int UsuarioId {get;set;}
    public Usuario? Usuario {get;set;}
    public int ProveedorId {get;set;}
    public Proveedor? Proveedor {get;set;}
}
