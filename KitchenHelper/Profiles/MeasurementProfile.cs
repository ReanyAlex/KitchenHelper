using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Entities.DbEntities.Measurement, Entities.Dtos.MeasurementDto>();
            CreateMap<Entities.Parameters.MeasurementForCreation, Entities.DbEntities.Measurement>();
            CreateMap<Entities.Parameters.MeasurementForUpdate, Entities.DbEntities.Measurement>();
        }
    }
}
