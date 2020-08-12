using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Core.Concrete
{
     public class UsersRecipes : Abstract.IUsersRecipes
    {
        private readonly IUsersRecipes _dal;

        public UsersRecipes(IUsersRecipes dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task AddAsync(Data.Entities.DbEntities.UsersRecipe entity)
        {
            await _dal.AddAsync(entity);
        }

        public async Task<Recipe> GetAsync(Data.Entities.DbEntities.UsersRecipe entity)
        {
            return await _dal.GetAsync(entity);
        }

        public async Task<IEnumerable<Recipe>> GetListAsync(int userId, ResourceParameters.Recipes resourceParameters)
        {
            return await _dal.GetListAsync(userId, resourceParameters);
        }

        public void RemoveAsync(Data.Entities.DbEntities.UsersRecipe entity)
        {
            _dal.RemoveAsync(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dal.SaveAsync();
        }
    }
}
