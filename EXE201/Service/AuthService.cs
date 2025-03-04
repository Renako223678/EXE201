using System.Linq;
using EXE201.Controllers.DTO;
using EXE201.Models;

namespace EXE201.Services;

public class AuthService : IAuthService
{
    private readonly EXE201Context _context;
    private readonly JwtService _jwtService;

    public AuthService(EXE201Context context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public string? Authenticate(LoginDTO loginDto)
    {
        var account = _context.Accounts
            .FirstOrDefault(a => a.UserName == loginDto.UserName && a.Password == loginDto.Password);

        if (account == null) return null;

        return _jwtService.GenerateToken(account);
    }
}
