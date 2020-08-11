using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        { 
            CreateMap<Entities.DbEntities.Recipe, Entities.Dtos.RecipeDto>();
            CreateMap<Entities.Parameters.RecipeForCreation, Entities.DbEntities.Recipe>();
            CreateMap<Entities.Parameters.RecipeForUpdate, Entities.DbEntities.Recipe>();
            CreateMap<Entities.DbEntities.Recipe, Entities.Parameters.RecipeForUpdate>();
        }
    }
}
