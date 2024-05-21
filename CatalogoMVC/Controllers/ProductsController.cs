using CatalogoMVC.Models;
using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CatalogoMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetProducts();

            if(result == null)
            {
                return View("Error");
            }
            return View(result.OrderBy(p => p.Description));
        }

        [HttpGet]
        public IActionResult CriarNovoProduto()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> CriarNovoProduto(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                productViewModel.ExpirationDate = productViewModel.ExpirationDate.ToUniversalTime();
                var result = await _productService.CreateProduct(productViewModel);

                if(result != null)
                    return RedirectToAction("Index");
            }

            ViewBag.Erro = "Erro ao criar o Produto";
            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarProduto(string code)
        {
            var result = await _productService.GetProductByCode( code);

            if(result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> AtualizarProduto(string code, ProductViewModel productViewModel)
            {
            if(ModelState.IsValid)
            {
                productViewModel.ExpirationDate = productViewModel.ExpirationDate.ToUniversalTime();
                var result = await _productService.UpdateProduct(code, productViewModel);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Erro = "Erro ao atualizar o produto";
            return View(productViewModel);
        }
    }
}
