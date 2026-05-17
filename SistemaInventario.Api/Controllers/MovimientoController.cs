using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Movimiento;
namespace SistemaInventario.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MovimientoController : ControllerBase
{
    private IMovimientoServices _movimientoServices;
    public MovimientoController(IMovimientoServices movimientoServices)
    {
        _movimientoServices = movimientoServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var movimiento = await _movimientoServices.ObtenerTodos();
        return Ok(movimiento);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var movimiento = await _movimientoServices.ObtenerPorId(Id);
        if (movimiento == null)
        {
            return NotFound();
        }
        return Ok(movimiento);
    }
    [Authorize(Roles = "Admin,Cajero")]
    [HttpPost]
    public async Task<IActionResult> Crear(CreateMovimientoDTOs createMovimientoDTOs)
    {
        await _movimientoServices.Crear(createMovimientoDTOs);
        return Created();
    }
    [Authorize(Roles = "SuperAdmin")]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _movimientoServices.Eliminar(Id);
        return NoContent();
    }

}