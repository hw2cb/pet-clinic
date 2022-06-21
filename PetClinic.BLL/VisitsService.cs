using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL
{
    public class VisitsService : IVisitsService
    {
        private IVisitsDAO _visitsDAO;
        private IAnimalsService _animalsService;
        public VisitsService(IVisitsDAO visitsDAO, IAnimalsService animalService)
        {
            _visitsDAO = visitsDAO;
            _animalsService = animalService;
        }
        public async Task<IEnumerable<VisitDTO>> GetVisitsToDay(string vetId)
        {
            if (string.IsNullOrEmpty(vetId))
                throw new ArgumentNullException("vet id is null");

            DateTime dateTimeStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime dateTimeEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            var visitsFromDB = await _visitsDAO.GetVisitsFilter(vetId, dateTimeStart, dateTimeEnd);
            List<VisitDTO> visits = new List<VisitDTO>();
            
            //TODO: AutoMapper
            for(int i=0; i < visitsFromDB.Count(); i++)
            {
                //заполнение модели DTO для транспортировки в PL, в будущем разобраться с AutoMapper
                //TODO: инкапсулировать в отдельный сервис для маппинга
                var visitDTO = new VisitDTO
                {
                    Id = visitsFromDB.ElementAt(i).Id,
                    VetId = visitsFromDB.ElementAt(i).VetId,
                    DateVisit = visitsFromDB.ElementAt(i).DateVisit,
                    Diagnosis = visitsFromDB.ElementAt(i).Diagnosis,
                    Comments = visitsFromDB.ElementAt(i).Comments,
                    Cost = visitsFromDB.ElementAt(i).Cost,
                    //начало заполнения Animal:
                    Animal = new AnimalDTO
                    {
                        Id = visitsFromDB.ElementAt(i).Animal.Id,
                        Name = visitsFromDB.ElementAt(i).Animal.Name,
                        DateOfBirthday = visitsFromDB.ElementAt(i).Animal.DateOfBirthday,
                        RegisterDate = visitsFromDB.ElementAt(i).Animal.RegisterDate,
                        OwnerId = visitsFromDB.ElementAt(i).Animal.OwnerId,
                        //начало заполнения Owner в Animal
                        Owner = new OwnerDTO 
                        { 
                            Id = visitsFromDB.ElementAt(i).Animal.Owner.Id, 
                            Name = visitsFromDB.ElementAt(i).Animal.Owner.Name, 
                            Surname = visitsFromDB.ElementAt(i).Animal.Owner.Surname,
                            Phone = visitsFromDB.ElementAt(i).Animal.Owner.Phone
                        },

                        Weight = visitsFromDB.ElementAt(i).Animal.Weight,
                        Height = visitsFromDB.ElementAt(i).Animal.Height,
                        TypeAnimalId = visitsFromDB.ElementAt(i).Animal.TypeAnimalId,
                        //начало заполнения TypeAnimal в Animal
                        TypeAnimal = new TypeAnimalDTO
                        {
                            Id = visitsFromDB.ElementAt(i).Animal.TypeAnimal.Id,
                            Type = visitsFromDB.ElementAt(i).Animal.TypeAnimal.Type
                        },
                        Breed = visitsFromDB.ElementAt(i).Animal.Breed
                    },
                    //конец заполнения AnimalDTO в классе VisitDTO
                    //начало заполнения RecipeDTO в класс VisitDTO
                    Recipe = new RecipeDTO
                    {
                        Id = visitsFromDB.ElementAt(i).Recipe.Id,
                        DateOfIssue = visitsFromDB.ElementAt(i).Recipe.DateOfIssue,
                        Duration = visitsFromDB.ElementAt(i).Recipe.Duration,
                        Treatment = visitsFromDB.ElementAt(i).Recipe.Treatment
                    }

                };
                visits.Add(visitDTO);

            }
            return visits;
        }
    }
}
