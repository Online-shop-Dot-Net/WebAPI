using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.Models.Users;

namespace WebAPI.Controllers.DataControllers
{
    public class OrdersController : ControllerBase
    {
        private UserManager<Customer> _userManager;

        public OrdersController(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetAllOrders")]
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(user.orders.ToList());
        }
    }
}
