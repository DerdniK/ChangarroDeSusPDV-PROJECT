using POSBackend_API.Dtos;

namespace POSBackend_API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetAllProductsResponseDto>> GetAllProductsAsync();
    }
}