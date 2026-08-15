using POSBackend_API.Dtos;

namespace POSBackend_API.Services;

public interface IAuthService
{
    //? LO QUE VA A REGRESAR                    LO QUE INGRESA
    Task<LoginResponseDto> LoginAsync(LoginRequestDto credentials);
}