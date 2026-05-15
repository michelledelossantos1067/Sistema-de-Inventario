
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Categoria;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaServices _categoriaServices;

    public CategoriaController(ICategoriaServices categoriaServices)
    {
        _categoriaServices = categoriaServices;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var categoria = await _categoriaServices.ObtenerTodos();
        return Ok(categoria);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var categoria = await _categoriaServices.ObtenerPorId(Id);
        if(categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateCategoriaDTOs createCategoriaDTOs)
    {
        await _categoriaServices.Crear(createCategoriaDTOs);
        return Created();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int Id,UpdateCategoriaDTOs updateCategoriaDTOs)
    {
        await _categoriaServices.Actualizar(Id,updateCategoriaDTOs);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _categoriaServices.Eliminar(Id);
        return NoContent();
    }
}