using EXE201.Controllers.DTO;

namespace EXE201.Services;

public interface IAuthService
{
    string? Authenticate(LoginDTO loginDto);
}
