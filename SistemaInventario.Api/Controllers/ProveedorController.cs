using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Proveedor;

[ApiController]
[Route("api/[controller]")]
public class ProveedorController : ControllerBase
{
    private IProveedorServices _proveedorServices;
    public ProveedorController(IProveedorServices proveedorServices)
    {
        _proveedorServices = proveedorServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var proveedor = await _proveedorServices.ObtenerTodos();
        return Ok(proveedor);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var proveedor = await _proveedorServices.ObtenerPorId(Id);
        if (proveedor == null)
        {
            return NotFound();
        }
        return Ok(proveedor);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateProveedorDTOs createProveedorDTOs)
    {
        await _proveedorServices.Crear(createProveedorDTOs);
        return Created();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _proveedorServices.Eliminar(Id);
        return NoContent();
    }

}