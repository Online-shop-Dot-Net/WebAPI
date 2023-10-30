using AutoMapper;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IProducentMapper
    {
        public ProducentGet MapToProducentGet(Producent order);

        public List<ProducentGet> MapToListProducentGet(List<Producent> orders);

        public Producent MapToProducent(ProducentPost orderPost);
    }

    public class ProducentMappers: IProducentMapper
    {

        private readonly IMapper _mapper;

        public ProducentMappers(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProducentGet MapToProducentGet(Producent order)
        {
            return _mapper.Map<ProducentGet>(order);
        }

        public Producent MapToProducent(ProducentPost orderPost)
        {
            return _mapper.Map<Producent>(orderPost);
        }

        public List<ProducentGet> MapToListProducentGet(List<Producent> producents)
        {
            return _mapper.Map<List<Producent>, List<ProducentGet>>(producents);
        }
    }
}
