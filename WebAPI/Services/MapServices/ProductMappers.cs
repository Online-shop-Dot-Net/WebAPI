using AutoMapper;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IProductMappers
    {
        public ProductGet MapToProductGet(Product product);

        public List<ProductGet> MapToListProductGet(List<Product> products);

        public Product MapToProduct(ProductPost productPost);
    }

    public class ProductMappers : IProductMappers
    {

        private readonly IMapper _mapper;

        public ProductMappers(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductGet MapToProductGet(Product product)
        {
            return _mapper.Map<ProductGet>(product);
        }

        public Product MapToProduct(ProductPost productPost)
        {
            return _mapper.Map<Product>(productPost);
        }

        public List<ProductGet> MapToListProductGet(List<Product> products)
        {
            return _mapper.Map<List<Product>, List<ProductGet>>(products);
        }
    }
}
