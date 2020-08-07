using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Entities.DbEntities.Measurement, Entities.Dtos.MeasurementDto>();
        }
    }
}
