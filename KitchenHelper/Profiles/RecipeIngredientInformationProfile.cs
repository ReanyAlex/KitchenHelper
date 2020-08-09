using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class RecipeIngredientInformationProfile : Profile
    {
        public RecipeIngredientInformationProfile()
        {
            CreateMap<Entities.DbEntities.RecipeIngredientInformation, Entities.Dtos.RecipeIngredientInformationDto>();
            CreateMap<Entities.Parameters.RecipeIngredientInformationForCreation, Entities.DbEntities.RecipeIngredientInformation>();
            CreateMap<Entities.Parameters.RecipeIngredientInformationForUpdate, Entities.DbEntities.RecipeIngredientInformation>();
        }
    }
}
