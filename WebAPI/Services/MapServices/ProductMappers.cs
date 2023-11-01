using AutoMapper;
using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IProductMappers
    {
        public Task<ProductGet> MapToProductGetAsync(Product product);

        public Task<List<ProductGet>> MapToListProductGet(List<Product> products);

        public Product MapToProduct(ProductPost productPost);
    }

    public class ProductMappers : IProductMappers
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductMappers(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<ProductGet> MapToProductGetAsync(Product product)
        {

            var mappedProduct = _mapper.Map<ProductGet>(product);

            var producent = await _context.Producents.FirstOrDefaultAsync(x => x.ProducentId == mappedProduct.ProducentId);

            if (product != null)
            {
                mappedProduct.ProducentName = producent.ProducentName;
            }

            return mappedProduct;
        }

        public Product MapToProduct(ProductPost productPost)
        {
            return _mapper.Map<Product>(productPost);
        }

        public async Task<List<ProductGet>> MapToListProductGet(List<Product> products)
        {
            var mappedProductList = _mapper.Map<List<Product>, List<ProductGet>>(products);
            foreach (var mappedProduct in mappedProductList)
            {
                var producent = await _context.Producents.FirstOrDefaultAsync(x => x.ProducentId == mappedProduct.ProducentId);

                if (producent != null)
                {
                    mappedProduct.ProducentName = producent.ProducentName;
                }
            }
            return mappedProductList;
        }
    }
}
