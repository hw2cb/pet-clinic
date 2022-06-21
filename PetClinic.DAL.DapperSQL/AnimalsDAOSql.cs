using Dapper;
using PetClinic.DAL.DapperSQL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.DAL.DapperSQL
{
    public class AnimalsDAOSql : BaseDAOSql, IAnimalsDAO
    {
        public AnimalsDAOSql(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task AddAnimal(Animal animal)
        {
            await WithConnection(async connection =>
            {
                if(animal.Id == 0)
                {
                    string query = $@"INSERT INTO Animal 
                                    (Name, DateOfBirthday, RegisterDate, OwnerId, Weight, Height, TypeAnimalId, Breed) 
                                    VALUES
                                    (@Name, @DateOfBirthday, @RegisterDate, @OwnerId, @Weight, @Height, @TypeAnimalId, @Breed)";
                    return await connection.ExecuteAsync(query, animal);
                }
                else
                {
                    string query = $@"UPDATE Animal 
                                    SET Name = @Name, DateOfBirthday = @DateOfBirthday, RegisterDate = @RegisterDate, 
                                    OwnerId = @OwnerId, Weight = @Weight, Height = @Height, TypeAnimalId = @TypeAnimalId, 
                                    Breed = @Breed ";
                    return await connection.ExecuteAsync(query, animal);
                }
            });
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await WithConnection(async connection =>
            {
                var query = $@"SELECT * FROM Animal 
                            INNER JOIN [Owner] ON Animal.OwnerId = [Owner].Id 
                            INNER JOIN [TypeAnimal] ON Animal.TypeAnimalId = [TypeAnimal].Id 
                            WHERE Animal.Id = @id";
                var animalDB = await connection.QueryAsync<Animal, Owner, TypeAnimal, Animal>(query,
                    map: (animal, owner, typeAnimal) =>
                    {
                        animal.Owner = owner;
                        animal.TypeAnimal = typeAnimal;
                        return animal;
                    },
                    param: new { id },
                    splitOn:"Id, Id"
                    );
                return animalDB.SingleOrDefault();
            });
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await WithConnection(async connection =>
            {
                var query = $@"SELECT animal.Id, animal.Name, animal.DateOfBirthday, animal.RegisterDate, animal.OwnerId, animal.Weight, 
                                animal.Height, animal.TypeAnimalId, animal.Breed,
                                o.Id, o.Surname, o.Name, o.Phone,
                                tA.Id, tA.Type
                                FROM Animal animal
                                INNER JOIN [Owner] o ON o.Id = animal.OwnerId
                                INNER JOIN [TypeAnimal] tA ON tA.Id = animal.TypeAnimalId";
                var animalDB = await connection.QueryAsync<Animal, Owner, TypeAnimal, Animal>(query,
                     map: (animal, owner, typeAnimal) =>
                     {
                         animal.Owner = owner;
                         animal.TypeAnimal = typeAnimal;
                         return animal;
                     },
                    splitOn: "Id,Id"
                    );
                return animalDB;
            });
        }

        public async Task<IEnumerable<Animal>> GetAnimalsFilter(int typeAnimalId)
        {
            return await WithConnection(async connection =>
            {
                return await connection.QueryAsync<Animal, Owner, TypeAnimal, Animal>($@"SELECT * FROM Animal 
                                                                                            INNER JOIN [Owner] ON Animal.OwnerId = [Owner].Id 
                                                                                            INNER JOIN [TypeAnimal] ON Animal.TypeAnimalId = [TypeAnimal].Id 
                                                                                            WHERE TypeAnimalId = @typeAnimalId",
                    map: (animal, owner, typeAnimal) =>
                    {
                        animal.Owner = owner;
                        animal.TypeAnimal = typeAnimal;
                        return animal;
                    },
                    splitOn: "Id,Id",
                    param: new { typeAnimalId });
            });
        }
    }
}
