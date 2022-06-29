using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Convert
{
    public static class TypeAnimalConverter
    {
        public static TypeAnimalDTO ConvertToDTO(TypeAnimal typeAnimal)
        {
            TypeAnimalDTO typeAnimalDTO = new TypeAnimalDTO
            {
                Id = typeAnimal.Id,
                Type = typeAnimal.Type
            };
            return typeAnimalDTO;
        }
        public static TypeAnimal ConvertFromDTO(TypeAnimalDTO typeAnimalDTO)
        {
            TypeAnimal typeAnimal = new TypeAnimal
            {
                Id = typeAnimalDTO.Id,
                Type = typeAnimalDTO.Type
            };
            return typeAnimal;
        }
    }
}
