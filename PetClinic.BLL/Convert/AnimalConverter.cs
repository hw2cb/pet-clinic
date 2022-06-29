using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Convert
{
    public static class AnimalConverter
    {
        public static AnimalDTO ConvertToDTO(Animal animal)
        {
            AnimalDTO animalDTO = new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                DateOfBirthday = animal.DateOfBirthday,
                RegisterDate = animal.RegisterDate,
                OwnerId = animal.OwnerId,
                Owner = OwnerConverter.ConvertToDTO(animal.Owner),
                Weight = animal.Weight,
                Height = animal.Height,
                TypeAnimal = TypeAnimalConverter.ConvertToDTO(animal.TypeAnimal),
                Breed = animal.Breed
            };
            return animalDTO;
        }
        public static Animal ConvertFromDTOWithoutHardProperty(AnimalDTO animalDTO)
        {
            //convert without hard property, only id

            Animal animal = new Animal
            {
                Name = animalDTO.Name,
                DateOfBirthday = animalDTO.DateOfBirthday,
                RegisterDate = animalDTO.RegisterDate,
                OwnerId = animalDTO.OwnerId,
                Weight = animalDTO.Weight,
                Height = animalDTO.Height,
                TypeAnimalId = animalDTO.TypeAnimalId,
                Breed = animalDTO.Breed
            };
            return animal;
        }
        public static Animal ConvertFromDTO(AnimalDTO animalDTO)
        {
            Animal animal = new Animal
            {
                Id = animalDTO.Id,
                Name = animalDTO.Name,
                DateOfBirthday = animalDTO.DateOfBirthday,
                RegisterDate = animalDTO.RegisterDate,
                OwnerId = animalDTO.OwnerId,
                Owner = OwnerConverter.ConvertFromDTO(animalDTO.Owner),
                Weight = animalDTO.Weight,
                Height = animalDTO.Height,
                TypeAnimal = TypeAnimalConverter.ConvertFromDTO(animalDTO.TypeAnimal),
                Breed = animalDTO.Breed
            };
            return animal;
        }
    }
}
