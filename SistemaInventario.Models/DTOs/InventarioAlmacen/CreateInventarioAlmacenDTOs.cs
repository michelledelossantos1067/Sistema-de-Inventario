

namespace SistemaInventario.Models.DTOs.InventarioAlmacen;

public class CreateInventarioAlmacenDTOs{
    public int ProductoId { get; set; }
    public int AlmacenId { get; set; }
    public int Stock { get; set; }
    public int StockMinimo {get;set;}
}