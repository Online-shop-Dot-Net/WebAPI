using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IOrderMapper
    {
        public Task<OrderGet> MapToOrderGet(Order order);

        public Task<List<OrderGet>> MapToListOrderGet(List<Order> orders);

        public Order MapToOrder(OrderPost orderPost);
    }

    public class OrderMappers : IOrderMapper
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public OrderMappers(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<OrderGet> MapToOrderGet(Order order)
        {
            var mappedOrder = _mapper.Map<OrderGet>(order);

            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == mappedOrder.ProductId);

            if (product != null)
            {
                mappedOrder.ProductName = product.ProductName;
                mappedOrder.ProductDescription = product.Description;
                mappedOrder.Price = product.Price;
            }

            return mappedOrder;
        }

        public Order MapToOrder(OrderPost orderPost)
        {
            return _mapper.Map<Order>(orderPost);
        }

        public async Task<List<OrderGet>> MapToListOrderGet(List<Order> orders)
        {
            var mappedOrderList = _mapper.Map<List<Order>, List<OrderGet>>(orders);
            foreach (var mappedOrder in mappedOrderList)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == mappedOrder.ProductId);

                if (product != null)
                {
                    mappedOrder.ProductName = product.ProductName;
                    mappedOrder.ProductDescription = product.Description;
                    mappedOrder.Price = product.Price;
                }
            }
            return mappedOrderList;
        }
    }
}
