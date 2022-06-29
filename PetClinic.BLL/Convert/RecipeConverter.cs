using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Convert
{
    public static class RecipeConverter
    {
        public static RecipeDTO ConvertToDTO(Recipe recipe)
        {
            RecipeDTO recipeDTO = new RecipeDTO
            {
                Id = recipe.Id,
                DateOfIssue = recipe.DateOfIssue,
                Duration = recipe.Duration,
                Treatment = recipe.Treatment
            };
            return recipeDTO;
        }
        public static Recipe ConvertFromDTO(RecipeDTO recipeDTO)
        {
            Recipe recipe = new Recipe
            {
                Id = recipeDTO.Id,
                DateOfIssue = recipeDTO.DateOfIssue,
                Duration = recipeDTO.Duration,
                Treatment = recipeDTO.Treatment
            };
            return recipe;
        }
    }
}
