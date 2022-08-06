using AutoMapper;
using JShop.ProductApi.Dtos;
using JShop.ProductApi.Models;
using JShop.ProductApi.Repositories;

namespace JShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var categoriesEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(categoriesEntity);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task DeleteCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
