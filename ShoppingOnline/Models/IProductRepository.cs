namespace ShoppingOnline.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int id);

        IEnumerable<Product> GetAllProducts();

        Product AddProduct(Product product);

        Product UpdateProduct(Product product);

        Product DeleteProduct(int id);
    }
}
