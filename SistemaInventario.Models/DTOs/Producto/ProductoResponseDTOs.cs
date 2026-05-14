using SistemaInventario.Models.Enums;

namespace SistemaInventario.Models.DTOs.Producto;

public class ProductoResponseDTOs{
    public int Id {get;set;}
    public string Nombre {get;set;} = string.Empty;
    public string Descripcion {get;set;} = string.Empty;
    public UnidadMedida MedidaUnidad{get;set;}
    public decimal PrecioVenta {get;set;}
    public string ImagenUrl {get;set;} = string.Empty;

    public int CategoriaId {get;set;}
}