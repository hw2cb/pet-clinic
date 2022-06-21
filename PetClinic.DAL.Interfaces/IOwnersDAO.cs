using PetClinic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces
{
    public interface IOwnersDAO
    {
        Task<int> AddOwner(Owner owner);
        Task<Owner> GetOwner(int? id);
        Task<IEnumerable<Owner>> GetOwners();
        Task<int> GetLastIdentity();

    }
}
