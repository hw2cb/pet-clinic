using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces
{
    public interface ITypesAnimalDAO
    {
        Task AddAnimalType(TypeAnimal type);
        Task<IEnumerable<TypeAnimal>> GetTypesAnimal();
        Task<TypeAnimal> GetTypeAnimal(int id);

    }
}
