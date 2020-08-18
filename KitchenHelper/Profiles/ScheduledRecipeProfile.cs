using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class ScheduledRecipeProfile : Profile
    {
        public ScheduledRecipeProfile()
        {
            CreateMap<Entities.Parameters.ScheduledRecipeForCreation, Entities.DbEntities.ScheduledRecipe>();
            CreateMap<Entities.Parameters.ScheduledRecipeForDeletion, Entities.DbEntities.ScheduledRecipe>();
            CreateMap<Entities.Parameters.ScheduledRecipeForRetrieval, Entities.DbEntities.ScheduledRecipe>();
            CreateMap<Entities.DbEntities.ScheduledRecipe, Entities.Dtos.ScheduledRecipeDto>();
        }
    }
}
