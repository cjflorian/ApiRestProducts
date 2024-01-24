using ProductMicroservicesProject.Models;

namespace ProductMicroservicesProject.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int product);
        void InsertProduct(Product product);

        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        void Save();
    }
}
