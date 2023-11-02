using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Data;

namespace Tests.Controllers.Fixtures
{
    public class ProducentSeedDataFixture : IDisposable
    {
        public ApplicationDbContext _dbContext { get; private set; }

        public ProducentSeedDataFixture()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            InitDatabase();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
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
                new Producent
                {
                    ProducentId = 2,
                    ProducentName = "TEST",
                    Description = "TEST"
                }
            );
            _dbContext.Add(
                new Producent
                {
                    ProducentId = 3,
                    ProducentName = "TEST",
                    Description = "TEST"
                }
            );
            _dbContext.Add(
                new Producent
                {
                    ProducentId = 4,
                    ProducentName = "TEST",
                    Description = "TEST"
                }
            );
            _dbContext.Add(
                new Producent
                {
                    ProducentId = 5,
                    ProducentName = "TEST",
                    Description = "TEST"
                }
            );

            _dbContext.SaveChanges();
        }
    }
}
