using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DataViews;
using WebAPI.Models;
using WebAPI.Services.MapServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.DataControllers
{
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductMappers _mapper;

        public ProductController(ApplicationDbContext dbContext, IProductMappers mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _context.Products.ToList();
            var getProducts = await _mapper.MapToListProductGet(products);
            return Ok(getProducts);
        }

        [HttpGet("GetProductsById")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product is null)
            {
                return BadRequest("There is no such producent.");
            }
            var getProduct = await _mapper.MapToProductGetAsync(product);
            return Ok(getProduct);
        }

        [HttpPost("NewProduct")]
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductPost productPost)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.MapToProduct(productPost);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok("Successfuly added");
            }

            return BadRequest("Data is not valid");
        }
    }
}
