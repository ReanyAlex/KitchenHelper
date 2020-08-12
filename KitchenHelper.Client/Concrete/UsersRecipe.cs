using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Core.Concrete
{
     public class UsersRecipe : Abstract.IUsersRecipe
    {
        private readonly IUsersRecipe _dal;

        public UsersRecipe(IUsersRecipe dal)
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

        public async Task<IEnumerable<Recipe>> GetListAsync(Data.Entities.DbEntities.UsersRecipe entity, ResourceParameters.Recipes resourceParameters)
        {
            return await _dal.GetListAsync(entity, resourceParameters);
        }

        public void RemoveAsync(Data.Entities.DbEntities.UsersRecipe entity)
        {
            _dal.RemoveAsync(entity);
        }
    }
}
