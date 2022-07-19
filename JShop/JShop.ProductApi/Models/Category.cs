namespace JShop.ProductApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    /// <summary>
    /// Define que eu tenha uma lista de produtos para uma categoria
    /// </summary>
    public ICollection<Product> Products { get; set; }
}
