using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using PetClinic.Entities;
using System.Threading.Tasks;

namespace PetClinic.BLL
{
    public class AnimalsService : IAnimalsService
    {
        private IAnimalsDAO _animalsDAO;
        private IOwnersDAO _ownerDAO;
        public AnimalsService(IAnimalsDAO animalsDAO, IOwnersDAO ownerDAO)
        {
            _animalsDAO = animalsDAO;
            _ownerDAO = ownerDAO;
        }
        public async Task<IEnumerable<AnimalDTO>> GetAllAnimals()
        {
            //TODO: AutoMapper

            var animalsFromDb = await _animalsDAO.GetAnimals();


            List<AnimalDTO> animalDTOs = new List<AnimalDTO>();

            for (int i=0; i< animalsFromDb.Count(); i++)
            {
                animalDTOs.Add(
                    new AnimalDTO
                    {
                        Id = animalsFromDb.ElementAt(i).Id,
                        Name = animalsFromDb.ElementAt(i).Name,
                        DateOfBirthday = animalsFromDb.ElementAt(i).DateOfBirthday,
                        RegisterDate = animalsFromDb.ElementAt(i).RegisterDate,
                        OwnerId = animalsFromDb.ElementAt(i).OwnerId,
                        Owner = new OwnerDTO 
                        { 
                            Id = animalsFromDb.ElementAt(i).Owner.Id ,
                            Name = animalsFromDb.ElementAt(i).Owner.Name,
                            Surname = animalsFromDb.ElementAt(i).Owner.Surname,
                            Phone = animalsFromDb.ElementAt(i).Owner.Phone
                        },
                        Weight = animalsFromDb.ElementAt(i).Weight,
                        Height = animalsFromDb.ElementAt(i).Height,
                        TypeAnimal = new TypeAnimalDTO 
                        { 
                            Id = animalsFromDb.ElementAt(i).TypeAnimal.Id, 
                            Type = animalsFromDb.ElementAt(i).TypeAnimal.Type 
                        },
                        Breed = animalsFromDb.ElementAt(i).Breed
                    });
            }
            
            return animalDTOs;

            
        }

        public async Task<AnimalDTO> GetAnimal(int id)
        {
            var animalFromDB = await _animalsDAO.GetAnimal(id);
            var animalDTO = new AnimalDTO
            {
                Id = animalFromDB.Id,
                Name = animalFromDB.Name,
                DateOfBirthday = animalFromDB.DateOfBirthday,
                RegisterDate = animalFromDB.RegisterDate,
                OwnerId = animalFromDB.OwnerId,
                Owner = new OwnerDTO
                {
                    Id = animalFromDB.Owner.Id,
                    Name = animalFromDB.Owner.Name,
                    Surname = animalFromDB.Owner.Surname,
                    Phone = animalFromDB.Owner.Phone
                },
                Weight = animalFromDB.Weight,
                Height = animalFromDB.Height,
                TypeAnimal = new TypeAnimalDTO
                {
                    Id = animalFromDB.TypeAnimal.Id,
                    Type = animalFromDB.TypeAnimal.Type
                },
                Breed = animalFromDB.Breed
            };
            return animalDTO;
        }

        public async Task RegisterAnimal(AnimalDTO animalDTO)
        {

            var lastIdOwner = await _ownerDAO.GetLastIdentity();

            Animal animal = new Animal
            {
                Name = animalDTO.Name,
                DateOfBirthday = animalDTO.DateOfBirthday,
                RegisterDate = DateTime.Now,
                OwnerId = lastIdOwner,
                Weight = animalDTO.Weight,
                Height = animalDTO.Height,
                TypeAnimalId = animalDTO.TypeAnimal.Id,
                Breed = animalDTO.Breed
            };
            await _animalsDAO.AddAnimal(animal);


        }
    }
}
