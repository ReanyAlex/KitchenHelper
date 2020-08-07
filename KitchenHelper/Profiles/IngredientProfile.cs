using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;


namespace KitchenHelper.API.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Entities.DbEntities.Ingredient, Entities.Dtos.IngredientDto>();
        }
    }
}
