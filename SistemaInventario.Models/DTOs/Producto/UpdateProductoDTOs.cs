using SistemaInventario.Models.Enums;
namespace SistemaInventario.Models.DTOs.Producto;

public class UpdateProductoDTOs{
    public int Id {get;set;}
    public string Nombre {get;set;} = string.Empty;
    public string Descripcion {get;set;} = string.Empty;
    public string Codigo {get;set;} = string.Empty;
    public UnidadMedida MedidaUnidad{get;set;}
    public decimal PrecioVenta {get;set;}
    public decimal PrecioCompra {get;set;}
    public string ImagenUrl {get;set;} = string.Empty;
    public int StockMinimo {get;set;}

    public int CategoriaId {get;set;}
    public int ProveedorId{get;set;}
}