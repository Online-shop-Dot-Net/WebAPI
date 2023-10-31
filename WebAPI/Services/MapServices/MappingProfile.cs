using AutoMapper;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderGet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.OrderCode))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<OrderPost, Order>()
                .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.OrderCode))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<Producent, ProducentGet>()
                .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.ProducentName,
                    opt => opt.MapFrom(src => src.ProducentName)
                );

            CreateMap<ProducentPost, Producent>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.ProducentName,
                    opt => opt.MapFrom(src => src.ProducentName)
                );

            CreateMap<Product, ProductGet>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

            CreateMap<ProductPost, Product>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProducentId, opt => opt.MapFrom(src => src.ProducentId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));
        }
    }
}
