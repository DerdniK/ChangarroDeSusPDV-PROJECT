// using Amazon.DynamoDBv2.DataModel;
//TODO: CAMBIAR DEPENDENCIAS POR EF
using Microsoft.AspNetCore.Http.HttpResults;
using POSBackend_API.Dtos;

namespace POSBackend_API.Services
{
    public class AuthService : IAuthService
    {
        // private readonly IDynamoDBContext _dynamoDbContext;
        // private readonly JwtTokenGenerator _jwtTokenGenerator;

        // public AuthService(IDynamoDBContext dynamoDbContext, JwtTokenGenerator jwtTokenGenerator) //? Inyeccion de dependencias, dynamo y jwt
        // {
        //     _dynamoDbContext = dynamoDbContext;
        //     _jwtTokenGenerator = jwtTokenGenerator;
        // }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            //TODO: Implementar la logica de negocios para registrar un usuario y devolver el response
            return new RegisterResponseDto();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            //TODO: Implementar la logica de negocios para registrar un usuario y devolver el response
            return new LoginResponseDto();
        }
    }
}