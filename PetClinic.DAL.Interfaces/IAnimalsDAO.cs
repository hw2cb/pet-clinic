using PetClinic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces
{
    public interface IAnimalsDAO
    {
        Task AddAnimal(Animal animal);
        Task<IEnumerable<Animal>> GetAnimals();
        Task<IEnumerable<Animal>> GetAnimalsFilter(int typeAnimalId);
        Task<Animal> GetAnimal(int id);


    }
}
