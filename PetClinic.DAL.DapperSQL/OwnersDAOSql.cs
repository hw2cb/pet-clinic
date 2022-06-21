using Dapper;
using PetClinic.DAL.DapperSQL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.DAL.DapperSQL
{
    public class OwnersDAOSql : BaseDAOSql, IOwnersDAO
    {
        public OwnersDAOSql(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> AddOwner(Owner owner)
        {
            return await WithConnection(async connection =>
            {
                if(owner.Id == 0)
                {
                    var query = "INSERT INTO Owner (Surname, Name, Phone) VALUES (@Surname, @Name, @Phone); SELECT CAST(SCOPE_IDENTITY() as int)";
                    return connection.Query<int>(query, owner).FirstOrDefault();
                    //return await connection.ExecuteAsync(query, owner);
                }
                else
                {
                    var query = "UPDATE Owner SET Surname = @Surname, Name = @Name, Phone= @Phone";
                    await connection.ExecuteAsync(query, owner);
                    return owner.Id;
                }
            });
        }

        public async Task<int> GetLastIdentity()
        {
            return await WithConnection(async connection =>
            {
                var query = "SELECT IDENT_CURRENT('Owner')";
                var lastId = await connection.QueryAsync<int>(query);

                return lastId.SingleOrDefault();
            });
        }

        public async Task<Owner> GetOwner(int? id)
        {
            return await WithConnection(async connection =>
            {
                var owners = await connection.QueryAsync<Owner>("SELECT * FROM Owner WHERE Id = @id", new { id });
                return owners.SingleOrDefault();
            });
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            return await WithConnection(async connection =>
            {
                return await connection.QueryAsync<Owner>("SELECT * FROM Owner");
            });
        }
    }
}
