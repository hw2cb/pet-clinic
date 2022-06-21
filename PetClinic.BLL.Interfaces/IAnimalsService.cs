using PetClinic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.BLL.Interfaces
{
    public interface IAnimalsService
    {
        Task RegisterAnimal(AnimalDTO animal);

        Task<IEnumerable<AnimalDTO>> GetAllAnimals();

        Task<AnimalDTO> GetAnimal(int id);


    }
}
