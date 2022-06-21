using Dapper;
using PetClinic.DAL.DapperSQL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.DapperSQL
{
    public class RecipeDAOSql : BaseDAOSql, IRecipesDAO
    {
        public RecipeDAOSql(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task AddRecipe(Recipe recipe)
        {
            if(recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            await WithConnection(async connection =>
            {
                if(recipe.Id == 0)
                {
                    string query = "INSERT INTO Recipe (DateOfIssue, Duration, Treatment) VALUES (@DateOfIssue, @Duration, @Treatment)";
                    return await connection.ExecuteAsync(query, recipe);
                }
                else
                {
                    string query = "UPDATE Recipe SET DateOfIssue = @DateOfIssue, Duration = @Duration, Treatment = @Treatment";
                    return await connection.ExecuteAsync(query, recipe);
                }

            });
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await WithConnection(async connection =>
            {
                string query = "SELECT * FROM Recipe WHERE Id = @id";
                return await connection.QueryFirstOrDefaultAsync<Recipe>(query);
            });
        }
    }
}
