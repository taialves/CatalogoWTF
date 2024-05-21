using CatalogoMVC.Models;

namespace CatalogoMVC.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProductByCode(string code);
        Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);
        Task<bool> UpdateProduct(string code, ProductViewModel productViewModel);
        Task<bool> DeleteProduct(string code);
    }
}
