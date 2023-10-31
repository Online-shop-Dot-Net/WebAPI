using AutoMapper;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IOrderMapper
    {
        public OrderGet MapToOrderGet(Order order);

        public List<OrderGet> MapToListOrderGet(List<Order> orders);

        public Order MapToOrder(OrderPost orderPost);
    }

    public class OrderMappers : IOrderMapper
    {
        private readonly IMapper _mapper;

        public OrderMappers(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderGet MapToOrderGet(Order order)
        {
            return _mapper.Map<OrderGet>(order);
        }

        public Order MapToOrder(OrderPost orderPost)
        {
            return _mapper.Map<Order>(orderPost);
        }

        public List<OrderGet> MapToListOrderGet(List<Order> orders)
        {
            return _mapper.Map<List<Order>, List<OrderGet>>(orders);
        }
    }
}
