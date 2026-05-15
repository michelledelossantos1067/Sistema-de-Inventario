using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.DetalleFactura;

[ApiController]
[Route("api/[controller]")]
public class DetalleFacturaController : ControllerBase
{
    private IDetalleFacturaServices _detalleFacturaServices;
    public DetalleFacturaController(IDetalleFacturaServices detalleFacturaServices)
    {
        _detalleFacturaServices = detalleFacturaServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var detallefactura = await _detalleFacturaServices.ObtenerTodos();
        return Ok(detallefactura);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var detallefactura = await _detalleFacturaServices.ObtenerPorId(Id);
        if (detallefactura == null)
        {
            return NotFound();
        }
        return Ok(detallefactura);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateDetalleFacturaDTOs createDetalleFacturaDTOs)
    {
        await _detalleFacturaServices.Crear(createDetalleFacturaDTOs);
        return Created();
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar(int Id, UpdateDetalleFacturaDTOs updateDetalleFacturaDTOs)
    {
        await _detalleFacturaServices.Actualizar(Id, updateDetalleFacturaDTOs);
        return Ok();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _detalleFacturaServices.Eliminar(Id);
        return NoContent();
    }

}