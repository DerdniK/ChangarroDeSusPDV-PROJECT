using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using POSBackend_API.Services;

namespace POSBackend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //? Segun yo [controller] va a ser el nombre del archivo en este caso "AuthController"
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService; 

    // La recibe aquí
        public AuthController(IAuthService authService) //? Inyeccion de dependencias del servicio 
        {
            _authService = authService;
        }

        
    }
}