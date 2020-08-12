using System.Collections.Generic;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UsersRecipe> UsersRecipes { get; set; }
    }
}
