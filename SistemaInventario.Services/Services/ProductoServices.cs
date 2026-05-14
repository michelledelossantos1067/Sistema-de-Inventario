using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Producto;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;

public class ProductoServices : IProductoServices{
    private readonly IProductoRepositories _productoRepositories;

    public ProductoServices(IProductoRepositories productoRepositories){
        _productoRepositories = productoRepositories;
    }
    public async Task<List<ProductoResponseDTOs>> ObtenerTodos(){
        var producto = await _productoRepositories.ObtenerTodos();
        return producto.Select(c => new ProductoResponseDTOs{
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
            MedidaUnidad = c.MedidaUnidad,
            PrecioVenta = c.PrecioVenta,
            ImagenUrl = c.ImagenUrl,
            CategoriaId = c.CategoriaId
        }).ToList();
    }
    public async Task<ProductoResponseDTOs?> ObtenerPorId(int Id){
        var producto = await _productoRepositories.ObtenerPorId(Id);
        if (producto == null){
            return null;
        };
        var productoDTOs = new ProductoResponseDTOs{
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            MedidaUnidad = producto.MedidaUnidad,
            PrecioVenta = producto.PrecioVenta,
            ImagenUrl = producto.ImagenUrl,
            CategoriaId = producto.CategoriaId,
        };
        
        return productoDTOs;
    }
    public async Task Crear(CreateProductoDTOs createProductoDTOs){
        var productoDTOs = new Producto{
            Codigo = createProductoDTOs.Codigo,
            Nombre = createProductoDTOs.Nombre,
            Descripcion = createProductoDTOs.Descripcion,
            MedidaUnidad = createProductoDTOs.MedidaUnidad,
            PrecioVenta = createProductoDTOs.PrecioVenta,
            PrecioCompra = createProductoDTOs.PrecioCompra,
            StockMinimo = createProductoDTOs.StockMinimo,
            ImagenUrl = createProductoDTOs.ImagenUrl,
            CategoriaId = createProductoDTOs.CategoriaId,
            ProveedorId = createProductoDTOs.ProveedorId
        };
        await _productoRepositories.Crear(productoDTOs);
    }
    public async Task Actualizar(int Id, UpdateProductoDTOs updateProductoDTOs){
        var productos = await _productoRepositories.ObtenerPorId(Id);
        if(productos == null){
            throw new Exception("El producto no existe.");
        };

        productos.Codigo = updateProductoDTOs.Codigo;
        productos.Nombre = updateProductoDTOs.Nombre;
        productos.Descripcion = updateProductoDTOs.Descripcion;
        productos.MedidaUnidad = updateProductoDTOs.MedidaUnidad;
        productos.PrecioVenta = updateProductoDTOs.PrecioVenta;
        productos.PrecioCompra = updateProductoDTOs.PrecioCompra;
        productos.StockMinimo = updateProductoDTOs.StockMinimo;
        productos.ImagenUrl = updateProductoDTOs.ImagenUrl;
        productos.CategoriaId = updateProductoDTOs.CategoriaId;
        productos.ProveedorId = updateProductoDTOs.ProveedorId;
        await _productoRepositories.Actualizar(Id,productos);
    }
    public async Task Eliminar(int Id){
        var productos = await _productoRepositories.ObtenerPorId(Id);
        if (productos == null){
            throw new Exception("El producto no existe.");
        };
        await _productoRepositories.Eliminar(Id);
    }
    
}
