using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Factura;

namespace SistemaInventario.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FacturaController : ControllerBase
{
    private IFacturaServices _facturaServices;
    public FacturaController(IFacturaServices facturaServices)
    {
        _facturaServices = facturaServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var factura = await _facturaServices.ObtenerTodos();
        return Ok(factura);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var factura = await _facturaServices.ObtenerPorId(Id);
        if (factura == null)
        {
            return NotFound();
        }
        return Ok(factura);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateFacturaDTOs createFacturaDTOs)
    {
        await _facturaServices.Crear(createFacturaDTOs);
        return Created();
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar(int Id, UpdateFacturaDTOs updateFacturaDTOs)
    {
        await _facturaServices.Actualizar(Id, updateFacturaDTOs);
        return Ok();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _facturaServices.Eliminar(Id);
        return NoContent();
    }

}