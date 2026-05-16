using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Usuario;
namespace SistemaInventario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioServices _usuarioServices;
    public UsuarioController(IUsuarioServices usuarioServices)
    {
        _usuarioServices = usuarioServices;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuario = await _usuarioServices.ObtenerTodos();
        return Ok(usuario);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id)
    {
        var usuario = await _usuarioServices.ObtenerPorId(Id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(CreateUsuarioDTOs createUsuarioDTOs)
    {
        await _usuarioServices.Crear(createUsuarioDTOs);
        return Created();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        await _usuarioServices.Eliminar(Id);
        return NoContent();
    }

}