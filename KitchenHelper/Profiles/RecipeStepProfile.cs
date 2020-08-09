using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class RecipeStepProfile : Profile
    {
        public RecipeStepProfile()
        {
            CreateMap<Entities.DbEntities.RecipeStep, Entities.Dtos.RecipeStepDto>();
            CreateMap<Entities.Parameters.RecipeStepForCreation, Entities.DbEntities.RecipeStep>();
            CreateMap<Entities.Parameters.RecipeStepForUpdate, Entities.DbEntities.RecipeStep>();
        }
    }
}
