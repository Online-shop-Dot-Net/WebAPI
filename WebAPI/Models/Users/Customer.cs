using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebAPI.Models.Data;

namespace WebAPI.Models.Users
{
    public class Customer : IdentityUser
    {
        private ILazyLoader LazyLoader { get; set; }

        private ICollection<Order> _orders;
        public ICollection<Order> orders
        {
            get => LazyLoader.Load(this, ref _orders);
            set => _orders = value;
        }
    }
}
