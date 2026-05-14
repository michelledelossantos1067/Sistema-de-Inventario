using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.Entities;

public class Producto{
    public int Id {get;set;}
    public string Codigo {get;set;} = string.Empty;
    public string Nombre {get;set;} = string.Empty;
    public string Descripcion {get;set;} = string.Empty;
    public int Stock {get;set;}
    public UnidadMedida MedidaUnidad {get;set;}
    public decimal PrecioVenta {get;set;}
    public decimal PrecioCompra {get;set;}
    public int StockMinimo {get;set;}
    public string ImagenUrl {get;set;} = string.Empty;

    public int CategoriaId {get;set;}
    public Categoria? Categoria {get;set;}

    public int ProveedorId {get;set;}
    public Proveedor? Proveedor {get;set;}
}

