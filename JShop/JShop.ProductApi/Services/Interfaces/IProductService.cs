using JShop.ProductApi.Dtos;

namespace JShop.ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task CreateProduct(ProductDto Product);
        Task UpdateProduct(ProductDto Product);
        Task DeleteProduct(int id);
    }
}
