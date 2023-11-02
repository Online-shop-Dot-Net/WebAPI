using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.Controllers.Fixtures;
using WebAPI.Controllers.DataControllers;
using WebAPI.Models;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;
using WebAPI.Services.MapServices;

namespace Tests.Controllers
{
    public class ProducentControllerTests : IClassFixture<ProducentSeedDataFixture>
    {
        private readonly MapperConfiguration mapperConfig;
        private ProducentSeedDataFixture _fixture;

        public ProducentControllerTests(ProducentSeedDataFixture fixture)
        {
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Producent, ProducentGet>()
                    .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(
                        dest => dest.ProducentName,
                        opt => opt.MapFrom(src => src.ProducentName)
                    );

                cfg.CreateMap<ProducentPost, Producent>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(
                        dest => dest.ProducentName,
                        opt => opt.MapFrom(src => src.ProducentName)
                    );

            });
            _fixture = fixture;
        }

        [Fact]
        public void TestGetAllProducents()
        {
            var mapper = new Mapper(mapperConfig);
            var producentMapper = new ProducentMappers(mapper);

            var producentController = new ProducentController(
                _fixture._dbContext,
                producentMapper
            );

            var allProducents = producentController.GetAllProducents();
            var okResult = allProducents as OkObjectResult;
            Assert.NotNull(okResult);

            var producents = okResult.Value as List<ProducentGet>;
            Assert.Equal(5, producents.Count());
        }

        [Fact]
        public void TestGetProducent()
        {
            var mapper = new Mapper(mapperConfig);
            var producentMapper = new ProducentMappers(mapper);

            var producentController = new ProducentController(
                _fixture._dbContext,
                producentMapper
            );

            var producentResult = producentController.GetProducentById(1);
            var okResult = producentResult as OkObjectResult;
            Assert.NotNull(okResult);

            var producent = okResult.Value as ProducentGet;
            Assert.Equal(1, producent.ProducentId);
            Assert.Equal("TEST", producent.ProducentName);
            Assert.Equal("TEST", producent.Description);
        }
    }
}
