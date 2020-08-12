using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Concrete
{
    class UsersRecipes : IUsersRecipe, IDisposable
    {

        private KitchenHelperDbContext _context;

        public UsersRecipes(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(UsersRecipe entity)
        {
            await _context.UsersRecipes.AddAsync(entity);
        }

        public async Task<Recipe> GetAsync(UsersRecipe entity)
        {
            var userRecipesContext = _context.UsersRecipes
                                        .Where(ur => ur.UserId == entity.UserId);

            return await _context.Recipes
                            .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Measurement)
                              .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Ingredient)
                            .Include(r => r.RecipeSteps)
                            .Join(userRecipesContext,
                                r => r.Id,
                                ur => ur.RecipeId,
                                (r, ur) => r)
                            .Where(r => r.Id == entity.RecipeId)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetListAsync(UsersRecipe entity, Entities.ResourceParameters.Recipes resourceParameters)
        {
            ParameterChecks.CheckResourceParameters(resourceParameters);

            var collection = _context.Recipes.AsQueryable<Recipe>();

            var userRecipescollection = _context.UsersRecipes.AsQueryable<UsersRecipe>().Where(ur => ur.UserId == entity.UserId);

            collection = collection.Include(r => r.Ingredients)
                                       .ThenInclude(i => i.Measurement)
                                      .Include(r => r.Ingredients)
                                       .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.RecipeSteps)
                                    .Join(userRecipescollection,
                                        r => r.Id,
                                        ur => ur.RecipeId,
                                        (r, ur) => r);

            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
                collection = collection.Where(i => i.Name.Contains(resourceParameters.SearchQuery.Trim()));

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                collection = resourceParameters.SortAsc ? collection.OrderBy(i => i.Name) : collection.OrderByDescending(i => i.Name);

            return await collection.Skip((resourceParameters.PageNumber - 1) * resourceParameters.PageSize).Take(resourceParameters.PageSize).ToListAsync();
        }

        public void RemoveAsync(UsersRecipe entity)
        {
            _context.UsersRecipes.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
