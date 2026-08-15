// using Amazon.DynamoDBv2.DataModel;
//TODO: CAMBIAR DEPENDENCIAS POR EF
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSBackend_API.Data;
using POSBackend_API.Dtos;
using POSBackend_API.Services;

namespace POSBackend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //? Segun yo [controller] va a ser el nombre del archivo en este caso "AuthController"
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly SupaDBContext _context; 

    // La recibe aquí
        public AuthController(IAuthService authService, SupaDBContext context) //? Inyeccion de dependencias del servicio 
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostLoginUsers(LoginRequestDto credentials)
        {
            try
            {
                var response = await _authService.LoginAsync(credentials);

                if(response.Success == false)
                {
                    return Unauthorized(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Esto te devolverá el mensaje exacto y el error interno de Postgres/EF Core
                return StatusCode(500, new 
                {
                    Error = ex.Message,
                    InnerError = ex.InnerException?.Message,
                    Stack = ex.StackTrace
                });
            }
            
        }

        
    }
}