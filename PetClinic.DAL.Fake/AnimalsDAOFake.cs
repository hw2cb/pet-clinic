using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Fake
{
    public class AnimalsDAOFake //: IAnimalsDAO
    {
        private static List<Animal> _animalsRepo;
        private IOwnersDAO _ownerDAO;
        private ITypesAnimalDAO _typesAnimalDAO;
        public AnimalsDAOFake()
        {
            //TODO: Init DAOs
            //_ownerDAO = new OwnersDAOFake();
            //_typesAnimalDAO = new TypesAnimalDAOFake();
            #region FAKE DATA
            Animal animal1 = new Animal()
            {
                Id = 1,
                Name = "Sandy",
                DateOfBirthday = new DateTime(2021, 02, 23),
                RegisterDate = DateTime.Now,
                OwnerId = 1,
                Weight = 24,
                Height = 30,
                TypeAnimalId = 1,
                Breed = "Английский Бульдог"
            };
            //animal1.Owner = _ownerDAO.GetOwner(animal1.OwnerId);
            //animal1.TypeAnimal = _typesAnimalDAO.GetTypeAnimal(animal1.TypeAnimalId);

            Animal animal2 = new Animal()
            {
                Id = 2,
                Name = "Sam",
                DateOfBirthday = new DateTime(2020, 02, 23),
                RegisterDate = DateTime.Now,
                OwnerId = 3,
                Weight = 34,
                Height = 45,
                TypeAnimalId = 1,
                Breed = "Лабрадор-ритривер"
            };
            //animal2.Owner = _ownerDAO.GetOwner(animal2.OwnerId);
            //animal2.TypeAnimal = _typesAnimalDAO.GetTypeAnimal(animal2.TypeAnimalId);

            Animal animal3 = new Animal()
            {
                Id = 3,
                Name = "John",
                DateOfBirthday = new DateTime(2018, 02, 23),
                RegisterDate = DateTime.Now,
                OwnerId = 2,
                Weight = 35,
                Height = 50,
                TypeAnimalId = 1,
                Breed = "Немецкая овчарка"
            };
            //animal3.Owner = _ownerDAO.GetOwner(animal3.OwnerId);
            //animal3.TypeAnimal = _typesAnimalDAO.GetTypeAnimal(animal3.TypeAnimalId);

            Animal animal4 = new Animal()
            {
                Id = 4,
                Name = "Markiz",
                DateOfBirthday = new DateTime(2020, 02, 23),
                RegisterDate = DateTime.Now,
                OwnerId = 4,
                Weight = 3,
                Height = 10,
                TypeAnimalId = 2,
                Breed = "Сфинкс"
            };
            //animal4.Owner = _ownerDAO.GetOwner(animal4.OwnerId);
            //animal4.TypeAnimal = _typesAnimalDAO.GetTypeAnimal(animal4.TypeAnimalId);

            Animal animal5 = new Animal()
            {
                Id = 5,
                Name = "Artur",
                DateOfBirthday = new DateTime(2019, 02, 23),
                RegisterDate = DateTime.Now,
                OwnerId = 4,
                Weight = 1,
                Height = 5,
                TypeAnimalId = 3,
                Breed = "Волнистый"
            };
            //animal5.Owner = _ownerDAO.GetOwner(animal5.OwnerId);
            //animal5.TypeAnimal = _typesAnimalDAO.GetTypeAnimal(animal5.TypeAnimalId);

            _animalsRepo = new List<Animal>();
            _animalsRepo.Add(animal1);
            _animalsRepo.Add(animal2);
            _animalsRepo.Add(animal3);
            _animalsRepo.Add(animal4);
            _animalsRepo.Add(animal5);
            #endregion 
        }
        public void AddAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("animal is null");

            _animalsRepo.Add(animal);
        }

        public Animal GetAnimal(int id)
        {
            var entryDb = _animalsRepo.FirstOrDefault(x => x.Id == id);
            return entryDb;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animalsRepo;
        }

        public IEnumerable<Animal> GetAnimalsFilter(TypeAnimal type)
        {
            return _animalsRepo.Where(x => x.TypeAnimalId == type.Id);
        }
    }
}
