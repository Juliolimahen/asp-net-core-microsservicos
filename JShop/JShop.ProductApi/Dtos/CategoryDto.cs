using JShop.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace JShop.ProductApi.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        /// <summary>
        /// Define que eu tenha uma lista de produtos para uma categoria
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}

