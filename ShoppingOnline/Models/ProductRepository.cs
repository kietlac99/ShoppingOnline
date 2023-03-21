namespace ShoppingOnline.Models
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            Product product = context.Products.Find(id);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public Product UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return product;
        }
    }
}
