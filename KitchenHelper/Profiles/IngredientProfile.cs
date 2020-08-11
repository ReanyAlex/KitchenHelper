using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;


namespace KitchenHelper.API.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Entities.DbEntities.Ingredient, Entities.Dtos.IngredientDto>();
            CreateMap<Entities.Parameters.IngredientForCreation, Entities.DbEntities.Ingredient>();
            CreateMap<Entities.Parameters.IngredientForUpdate, Entities.DbEntities.Ingredient>();
            CreateMap<Entities.DbEntities.Ingredient, Entities.Parameters.IngredientForUpdate>();

        }
    }
}
