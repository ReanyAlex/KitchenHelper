using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class RecipeStepProfile : Profile
    {
        public RecipeStepProfile()
        {
            CreateMap<Entities.DbEntities.RecipeStep, Entities.Dtos.RecipeStepDto>();
        }
    }
}
