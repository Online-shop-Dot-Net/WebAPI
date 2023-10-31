using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;
using WebAPI.Models.Users;
using WebAPI.Services.MapServices;

namespace WebAPI.Controllers.DataControllers
{
    public class OrdersController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IOrderMapper _mapper;

        public OrdersController(UserManager<Customer> userManager, ApplicationDbContext dbContext, IOrderMapper mapper)
        {
            _userManager = userManager;
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrders")]
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = user.orders.ToList();
            var getOrders = _mapper.MapToListOrderGet(orders);
            return Ok(getOrders);
        }

        [HttpGet("GetOrderById")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var order = user.orders.Where(o => o.Id == id).FirstOrDefault();
            if (order is null)
            {
                return BadRequest("There is no such order.");
            }
            var getOrder = _mapper.MapToOrderGet(order);
            return Ok(getOrder);
        }

        [HttpPost("NewOrder")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(OrderPost orderPost)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.MapToOrder(orderPost);
                var user = await _userManager.GetUserAsync(User);
                order.CustomerId = user.Id;
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return Ok("Successfuly added");
            }

            return BadRequest("Data is not valid");
        }
    }
}
