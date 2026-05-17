using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Producto;
namespace SistemaInventario.Api.Controllers;
[Authorize]
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
    [Authorize(Roles = "Admin,Cajero")]
    [HttpPost]
    public async Task<IActionResult> Crear(CreateProductoDTOs createProductoDTOs)
    {
        await _productoServices.Crear(createProductoDTOs);
        return Created();
    }
    [Authorize(Roles = "Admin,Cajero")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int Id,UpdateProductoDTOs updateProductoDTOs)
    {
        await _productoServices.Actualizar(Id,updateProductoDTOs);
        return Ok();
    }
    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _productoServices.Eliminar(Id);
        return NoContent();
    }

}