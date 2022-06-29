using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using PetClinic.Entities;
using System.Threading.Tasks;
using PetClinic.BLL.Convert;

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
                animalDTOs.Add(AnimalConverter.ConvertToDTO(animalsFromDb.ElementAt(i)));
            }
            
            return animalDTOs;

            
        }

        public async Task<AnimalDTO> GetAnimal(int id)
        {
            var animalFromDB = await _animalsDAO.GetAnimal(id);
            var animalDTO = AnimalConverter.ConvertToDTO(animalFromDB);
            return animalDTO;
        }

        public async Task RegisterAnimal(AnimalDTO animalDTO)
        {

            var lastIdOwner = await _ownerDAO.GetLastIdentity();
            Animal animal = AnimalConverter.ConvertFromDTOWithoutHardProperty(animalDTO);

            animal.OwnerId = lastIdOwner;

            await _animalsDAO.AddAnimal(animal);


        }
    }
}
