using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Models.DTOs.Login;


namespace SistemaInventario.Services.Services;
public class AuthService : IAuthServices{
    private readonly IUsuarioRepositories _usuarioRepositories;
    private readonly IConfiguration _configuration;

    public AuthService(IUsuarioRepositories usuarioRepositories,IConfiguration configuration){
        _usuarioRepositories = usuarioRepositories;
        _configuration = configuration;
    }
    public async Task<LoginResponseDTOs?> Login(LoginDTOs loginDTOs){
        if (loginDTOs.Email == null)
        {
            return null;
        };
        var usuario = await _usuarioRepositories.ObtenerPorEmail(loginDTOs.Email!);
        if (usuario == null)
        {
            return null;
        };
        if (usuario.Password != loginDTOs.Password)
        {
            return null;
        };
        var claims = new[]{
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Rol.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: creds
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginResponseDTOs
        {
            Token = tokenString,
            Rol = usuario.Rol.ToString(),
            Nombre = usuario.Nombre
        };
    }
}
