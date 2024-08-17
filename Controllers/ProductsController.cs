using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApiRESTful.Data;
using ProductApiRESTful.Models;
using ProductApiRESTful.Services;

namespace ProductApiRESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductsController(ApplicationDbContext dbContext)
        {
            productService = new ProductService(dbContext);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Products> Getproduct(int id)
        {
            var product = productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Products> AddUProducts(AddProductdto product)
        {
            productService.AddProduct(product);
            return CreatedAtAction(nameof(Getproduct), new { name = product.Name }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<Products> UpdateProd(int id ,UpdateProduct products)
        {
            if(id != products.Id)
            {
                return BadRequest();
            }

            var prod = productService.GetProductByID(id);
            if(prod == null)
            {
                return NotFound();
            }

            productService.UpdateProducts(products);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var prod = productService.GetProductByID(id);
            if(prod == null)
            {
                return NotFound();
            }

            productService.DeleteProduct(prod);
            return NoContent();
        }

    }
}
