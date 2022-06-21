using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Interfaces
{
    public interface ITypesAnimalService
    {
        Task<IEnumerable<TypeAnimalDTO>> GetTypesAnimal();
    }
}
