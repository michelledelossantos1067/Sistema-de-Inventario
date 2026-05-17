using SistemaInventario.Models.DTOs.Login;

namespace SistemaInventario.Application.Interfaces.Services;

public interface IAuthServices{
    public Task<LoginResponseDTOs?> Login(LoginDTOs loginDTOs);
}