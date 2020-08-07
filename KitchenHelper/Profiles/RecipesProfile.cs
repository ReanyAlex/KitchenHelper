using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        { 
            CreateMap<Entities.DbEntities.Recipe, Entities.Dtos.RecipeDto>();
        }
    }
}
