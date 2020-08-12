using AutoMapper;
using Entities = KitchenHelper.API.Data.Entities;

namespace KitchenHelper.API.Profiles
{
    public class UsersRecipeProfile : Profile
    {
        public UsersRecipeProfile()
        {
            CreateMap<Entities.Parameters.UsersRecipeForCreation, Entities.DbEntities.UsersRecipe>();
            CreateMap<Entities.Parameters.UsersRecipeForDeletion, Entities.DbEntities.UsersRecipe>();
            CreateMap<Entities.Parameters.UsersRecipeForRetrieval, Entities.DbEntities.UsersRecipe>();
        }
    }
}
