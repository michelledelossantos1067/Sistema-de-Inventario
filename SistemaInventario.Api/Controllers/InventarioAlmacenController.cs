
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.InventarioAlmacen;
namespace SistemaInventario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventarioAlmacenController : ControllerBase
{
    private readonly IInventarioAlmacenServices _inventarioAlmacenServices;

    public InventarioAlmacenController(IInventarioAlmacenServices inventarioAlmacenServices)
    {
        _inventarioAlmacenServices = inventarioAlmacenServices;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var almacen = await _inventarioAlmacenServices.ObtenerTodos();
        return Ok(almacen);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var almacen = await _inventarioAlmacenServices.ObtenerPorId(Id);
        if(almacen == null)
        {
            return NotFound();
        }
        return Ok(almacen);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateInventarioAlmacenDTOs createInventarioAlmacenDTOs)
    {
        await _inventarioAlmacenServices.Crear(createInventarioAlmacenDTOs);
        return Created();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int Id,UpdateInventarioAlmacenDTOs updateInventarioAlmacenDTOs)
    {
        await _inventarioAlmacenServices.Actualizar(Id,updateInventarioAlmacenDTOs);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _inventarioAlmacenServices.Eliminar(Id);
        return NoContent();
    }
}