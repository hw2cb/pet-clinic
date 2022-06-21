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
    public class TypesAnimalDAOSql : BaseDAOSql, ITypesAnimalDAO
    {
        public TypesAnimalDAOSql(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task AddAnimalType(TypeAnimal type)
        {
            if(type == null)
                throw new ArgumentNullException(nameof(type));

            await WithConnection(async connection =>
            {
                if(type.Id == 0)
                {
                    string query = "INSERT INTO TypeAnimal (Type) VALUES (@type)";

                    return await connection.ExecuteAsync(query, type);
                }
                else
                {
                    string query = "UPDATE TypeAnimal SET Type = @type";

                    return await connection.ExecuteAsync(query, type);
                }

            });
        }

        public async Task<TypeAnimal> GetTypeAnimal(int id)
        {
            return await WithConnection(async connection =>
            {
                string query = "SELECT * FROM TypeAnimal WHERE Id = @id";
                return await connection.QueryFirstOrDefaultAsync<TypeAnimal>(query, param: new { id });
            });
        }

        public async Task<IEnumerable<TypeAnimal>> GetTypesAnimal()
        {
            return await WithConnection(async connection =>
            {
                string query = "SELECT * FROM TypeAnimal";
                return await connection.QueryAsync<TypeAnimal>(query);
            });
        }
    }
}
