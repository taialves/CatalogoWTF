using CatalogoMVC.Models;
using System.Text;
using System.Text.Json;

namespace CatalogoMVC.Services
{
    public class ProductService : IProductService
    {
        private const string apiEndpoint = "/products/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;

        private ProductViewModel productVM;
        private IEnumerable<ProductViewModel> productsVM;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            var client = _httpClientFactory.CreateClient("CatalogoApi");
            var produto = JsonSerializer.Serialize(productViewModel);
            StringContent content = new StringContent(produto, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVM = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>
                        (apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return productVM;
            }
        }

        public async Task<bool> DeleteProduct(string code)
        {
            var client = _httpClientFactory.CreateClient("CatalogoApi");

            using (var response = await client.DeleteAsync(apiEndpoint + code))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ProductViewModel> GetProductByCode(string code)
        {
            var client = _httpClientFactory.CreateClient("CatalogoApi");

            using (var response = await client.GetAsync(apiEndpoint + code))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVM = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>
                        (apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return productVM;
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("CatalogoApi");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productsVM = await JsonSerializer
                        .DeserializeAsync<IEnumerable<ProductViewModel>>
                        (apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return productsVM;
            }
        }

        public async Task<bool> UpdateProduct(string code, ProductViewModel productViewModel)
        {
            var client = _httpClientFactory.CreateClient("CatalogoApi");

            using (var response = await client.PutAsJsonAsync(apiEndpoint + code, productViewModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
