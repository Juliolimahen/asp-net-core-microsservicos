using AutoMapper;
using JShop.ProductApi.Dtos;
using JShop.ProductApi.Models;
using JShop.ProductApi.Repositories;

namespace JShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            _productRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var categoriesEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(categoriesEntity);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var categoriesEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(categoriesEntity);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productEntity);
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
