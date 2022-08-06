using JShop.ProductApi.Dtos;

namespace JShop.ProductApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<IEnumerable<CategoryDto>> GetCategoriesProducts();
        Task<CategoryDto> GetCategoryById(int id);
        Task CreateCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}
