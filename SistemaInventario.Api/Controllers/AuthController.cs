using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Login;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthServices _authServices;
    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginDTOs loginDTOs)
    {
        var login = await _authServices.Login(loginDTOs);
        if (login == null)
        {
            return Unauthorized();
        }
        return Ok(login);
    }
}