using SistemaInventario.Models.Entities;

namespace SistemaInventario.Models.Entities;
public class InventarioAlmacen
{
    public int Id {get;set;}
    public int ProductoId {get;set;}
    public Producto? Producto {get;set;}
    public int AlmacenId {get;set;}
    public Almacen? Almacen {get;set;}
    public int Stock {get;set;}
    public int StockMinimo {get;set;}
}
