using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Producto;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private IProductoServices _productoServices;
    public ProductoController(IProductoServices productoServices)
    {
        _productoServices = productoServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var producto = await _productoServices.ObtenerTodos();
        return Ok(producto);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var producto = await _productoServices.ObtenerPorId(Id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateProductoDTOs createProductoDTOs)
    {
        await _productoServices.Crear(createProductoDTOs);
        return Created();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _productoServices.Eliminar(Id);
        return NoContent();
    }

}