using Catalogo.API.Context;
using Catalogo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Catalogo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.AsNoTracking().ToList();
            if(products is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return products;
        }

        [HttpGet("{code}", Name ="ObterProduto")]
        public ActionResult<Product> Get(string code)
        {
            var product = _context.Products.FirstOrDefault(p => p.Code == code);
            if(product == null)
            {
                return NotFound("Produto não encontrado");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if(product == null)
                return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { code = product.Code }, product);
        }

        [HttpPut("{code}")]
        public ActionResult Put(string code, Product product)
        {
            if(code != product.Code)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{code}")]
        public ActionResult Delete(string code)
        {
            var product = _context.Products.FirstOrDefault(p =>p.Code == code);

            if(product is null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
