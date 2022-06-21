using Dapper;
using PetClinic.DAL.DapperSQL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.DAL.DapperSQL
{
    public class VisitsDAOSql : BaseDAOSql, IVisitsDAO
    {
        public VisitsDAOSql(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task AddVisit(Visit visit)
        {
            if (visit == null)
                throw new ArgumentNullException("object Visit is null");

            await WithConnection(async connection =>
            {
                if(visit.Id == 0)
                {
                    string query = $@"INSERT INTO Visit 
                                    (VetId, DateVisit, AnimalId, Diagnosis, RecipeId, Comments, Cost)
                                    VALUES 
                                    (@VetId, @DateVisit, @AnimalId, @Diagnosis, @RecipeId, @Comments, @Cost)";
                    return await connection.ExecuteAsync(query, visit);
                }
                else
                {
                    string query = $@"UPDATE Visit 
                                    SET VetId = @VetId, DateVisit = @DateVisit, AnimalId=@AnimalId,
                                    Diagnosis = @Diagnosis, RecipeId = @RecipeId, Comments = @Comments, Cost = @Cost) ";
                    return await connection.ExecuteAsync(query, visit);
                }
            });
        }

        public async Task<Visit> GetVisit(int id)
        {
            return await WithConnection(async connection =>
            {
                string query = $@"SELECT * FROM Visit 
                                INNER JOIN Animal ON Visit.AnimalId = Animal.Id 
                                INNER JOIN Recipe ON Visit.RecipeId = Recipe.Id 
                                WHERE Visit.Id = @id";
                var visitDb = await connection.QueryAsync<Visit, Animal, Recipe, Visit>(query,
                    map: (visit, animal, recipe) =>
                    {
                        visit.Animal = animal;
                        visit.Recipe = recipe;
                        return visit;
                    },
                    splitOn: "Id,Id",
                    param: new { id });
                return visitDb.SingleOrDefault();
            });
        }

        public async Task<IEnumerable<Visit>> GetVisits()
        {
            return await WithConnection(async connection =>
            {
                string query = $@"SELECT * FROM Visit 
                                INNER JOIN Animal ON Visit.AnimalId = Animal.Id 
                                INNER JOIN Recipe ON Visit.RecipeId = Recipe.Id";
                return await connection.QueryAsync<Visit, Animal, Recipe, Visit>(query,
                    map: (visit, animal, recipe) =>
                    {
                        visit.Animal = animal;
                        visit.Recipe = recipe;
                        return visit;
                    },
                    splitOn: "Id,Id");
            });
        }
        public async Task<IEnumerable<Visit>> GetVisitsFilter(string vetId, DateTime startDate, DateTime endDate)
        {
            return await WithConnection(async connection =>
            {
                string query = $@"SELECT * FROM Visit 
                                    INNER JOIN Animal ON Visit.AnimalId = Animal.Id 
                                    INNER JOIN Recipe ON Visit.RecipeId = Recipe.Id 
                                    WHERE Visit.DateVisit 
                                    BETWEEN @startDate AND @endDate";
                return await connection.QueryAsync<Visit, Animal, Recipe, Visit>(query,
                    map: (visit, animal, recipe) =>
                    {
                        visit.Animal = animal;
                        visit.Recipe = recipe;
                        return visit;
                    },
                    splitOn: "Id,Id",
                    param: new {startDate, endDate});
            });
        }
    }
}
