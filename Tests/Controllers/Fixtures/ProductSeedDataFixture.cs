using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Data;
using WebAPI.Models;

namespace Tests.Controllers.Fixtures
{
    public class ProductSeedDataFixture : IDisposable
    {
        public ApplicationDbContext _dbContext { get; private set; }

        public ProductSeedDataFixture()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db_product_tests");
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            InitDatabase();
        }

        private void InitDatabase()
        {
            _dbContext.Add(
                new Producent
                {
                    ProducentId = 1,
                    ProducentName = "TEST",
                    Description = "TEST"
                }
            );

            _dbContext.Add(
                new Product
                {
                    ProductId = 1,
                    ProductName = "TEST",
                    Description = "TEST",
                    ProducentId = 1
                }
            );

            _dbContext.Add(
                new Product
                {
                    ProductId = 2,
                    ProductName = "TEST",
                    Description = "TEST",
                    ProducentId = 1
                }
            );

            _dbContext.Add(
                new Product
                {
                    ProductId = 3,
                    ProductName = "TEST",
                    Description = "TEST",
                    ProducentId = 1
                }
            );

            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
