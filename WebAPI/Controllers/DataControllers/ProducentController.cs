using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DataViews;
using WebAPI.Models;
using WebAPI.Services.MapServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.DataControllers
{
    public class ProducentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProducentMapper _mapper;

        public ProducentController(ApplicationDbContext dbContext, IProducentMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducents")]
        public IActionResult GetAllProducents()
        {
            var producents = _context.Producents.ToList();
            var getProducents = _mapper.MapToListProducentGet(producents);
            return Ok(getProducents);
        }

        [HttpGet("GetProducentById")]
        public IActionResult GetProducentById(int id)
        {
            var producent = _context.Producents.Where(p => p.ProducentId == id).FirstOrDefault();
            if (producent is null)
            {
                return BadRequest("There is no such producent.");
            }
            var getProducent = _mapper.MapToProducentGet(producent);
            return Ok(getProducent);
        }

        [HttpPost("NewProducent")]
        [Authorize]
        public async Task<IActionResult> CreateProducent(ProducentPost producentPost)
        {
            if (ModelState.IsValid)
            {
                var producent = _mapper.MapToProducent(producentPost);
                _context.Producents.Add(producent);
                await _context.SaveChangesAsync();
                return Ok("Successfuly added");
            }

            return BadRequest("Data is not valid");
        }
    }
}
