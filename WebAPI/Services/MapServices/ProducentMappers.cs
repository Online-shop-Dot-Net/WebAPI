using AutoMapper;
using WebAPI.Models.Data;
using WebAPI.Models.DataViews;

namespace WebAPI.Services.MapServices
{
    public interface IProducentMapper
    {
        public ProducentGet MapToProducentGet(Producent producent);

        public List<ProducentGet> MapToListProducentGet(List<Producent> producents);

        public Producent MapToProducent(ProducentPost producentPost);
    }

    public class ProducentMappers: IProducentMapper
    {

        private readonly IMapper _mapper;

        public ProducentMappers(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProducentGet MapToProducentGet(Producent producent)
        {
            return _mapper.Map<ProducentGet>(producent);
        }

        public Producent MapToProducent(ProducentPost producentPost)
        {
            return _mapper.Map<Producent>(producentPost);
        }

        public List<ProducentGet> MapToListProducentGet(List<Producent> producents)
        {
            return _mapper.Map<List<Producent>, List<ProducentGet>>(producents);
        }
    }
}
