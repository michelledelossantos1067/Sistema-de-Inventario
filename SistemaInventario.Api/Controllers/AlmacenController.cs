
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Almacen;
namespace SistemaInventario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlmacenController : ControllerBase
{
    private readonly IAlmacenServices _almacenServices;

    public AlmacenController(IAlmacenServices almacenServices)
    {
        _almacenServices = almacenServices;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var almacen = await _almacenServices.ObtenerTodos();
        return Ok(almacen);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var almacen = await _almacenServices.ObtenerPorId(Id);
        if(almacen == null)
        {
            return NotFound();
        }
        return Ok(almacen);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateAlmacenDTOs createAlmacenDTOs)
    {
        await _almacenServices.Crear(createAlmacenDTOs);
        return Created();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int Id,UpdateAlmacenDTOs updateAlmacenDTOs)
    {
        await _almacenServices.Actualizar(Id,updateAlmacenDTOs);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _almacenServices.Eliminar(Id);
        return NoContent();
    }
}