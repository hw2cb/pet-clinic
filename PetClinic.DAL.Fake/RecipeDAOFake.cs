using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Fake
{
    public class RecipeDAOFake //: IRecipesDAO
    {
        private static List<Recipe> _recipes;
        public RecipeDAOFake()
        {
            _recipes = new List<Recipe>();
        }
        public void AddRecipe(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException("recipe is null");

            _recipes.Add(recipe);
        }

        public Recipe GetRecipe(int id)
        {
            return _recipes.FirstOrDefault(x => x.Id == id);
        }
    }
}
