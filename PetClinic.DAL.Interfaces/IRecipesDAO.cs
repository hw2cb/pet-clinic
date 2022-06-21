using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces
{
    public interface IRecipesDAO
    {
        Task AddRecipe(Recipe recipe);
        Task<Recipe> GetRecipe(int id);

    }
}
