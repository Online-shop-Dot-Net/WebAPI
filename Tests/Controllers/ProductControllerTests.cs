using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Controllers.Fixtures;
using WebAPI.Controllers.DataControllers;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;
using WebAPI.Services.MapServices;

namespace Tests.Controllers
{
    public class ProductControllerTests : IClassFixture<ProductSeedDataFixture> 
    {
        private readonly MapperConfiguration mapperConfig;
        private ProductSeedDataFixture _fixture;

        public ProductControllerTests(ProductSeedDataFixture fixture)
        {
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductGet>()
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

                cfg.CreateMap<ProductPost, Product>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            });
            _fixture = fixture;
        }

        [Fact]
        public async void TestGetAllProducts()
        {
            var mapper = new Mapper(mapperConfig);
            var productMapper = new ProductMappers(mapper, _fixture._dbContext);

            var productController = new ProductController(
                _fixture._dbContext,
                productMapper
            );

            var allProducts = await productController.GetAllProducts();
            var okResult = allProducts as OkObjectResult;
            Assert.NotNull(okResult);

            var products = okResult.Value as List<ProductGet>;
            Assert.Equal(3, products.Count());
        }

        [Fact]
        public async void TestGetProduct()
        {
            var mapper = new Mapper(mapperConfig);
            var productMapper = new ProductMappers(mapper, _fixture._dbContext);

            var userService = new ProductController(
                _fixture._dbContext,
                productMapper
            );

            var productResult = userService.GetProductsById(1);
            var okResult = await productResult as OkObjectResult;
            Assert.NotNull(okResult);

            var product = okResult.Value as ProductGet;
            Assert.Equal(1, product.ProductId);
            Assert.Equal(1, product.ProducentId);
            Assert.Equal("TEST", product.ProducentName);
            Assert.Equal("TEST", product.Description);
        }

    }
}
