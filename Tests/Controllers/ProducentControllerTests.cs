using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SendGrid;
using WebAPI.Controllers.DataControllers;
using WebAPI.Models;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;
using WebAPI.Services.MailService;
using WebAPI.Services.MapServices;

namespace Tests.Controllers
{
    public class ProducentControllerTests
    {
        private MapperConfiguration mapperConfig;
        public ProducentControllerTests()
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
        }

        [Fact]
        public void TestGetAllProducents()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var mapper = new Mapper(mapperConfig);
            var producentMapper = new ProducentMappers(mapper);

            _dbContext.Add(new Producent { ProducentId = 1, ProducentName = "TEST", Description = "TEST" });
            _dbContext.Add(new Producent { ProducentId = 2, ProducentName = "TEST", Description = "TEST" });
            _dbContext.Add(new Producent { ProducentId = 3, ProducentName = "TEST", Description = "TEST" });
            _dbContext.Add(new Producent { ProducentId = 4, ProducentName = "TEST", Description = "TEST" });
            _dbContext.Add(new Producent { ProducentId = 5, ProducentName = "TEST", Description = "TEST" });

            _dbContext.SaveChanges();

            ProducentController userService = new ProducentController(_dbContext, producentMapper);

            var allProducents = userService.GetAllProducents();
            var okResult = allProducents as OkObjectResult;
            Assert.NotNull(okResult);

            var producents = okResult.Value as List<ProducentGet>;
            Assert.Equal(5, producents.Count());
        }
    }
}
