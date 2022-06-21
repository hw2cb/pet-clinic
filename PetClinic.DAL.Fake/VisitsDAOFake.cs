using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Fake
{
    public class VisitsDAOFake //: IVisitsDAO
    {
        private static List<Visit> _visits;
        public VisitsDAOFake()
        {
            #region FAKE DATE
            Visit visit1 = new Visit
            {
                Id = 1,
                DateVisit = new DateTime(2022, 01, 12),
                AnimalId = 1,
                VetId = "f91df8ac-13a9-49bd-9096-6141970e00ee",
                Diagnosis = "-",
                RecipeId = null,
                Comments = "Первый визит к доктору, прием",
                Cost = 150.0M
            };
            Visit visit2 = new Visit
            {
                Id = 2,
                DateVisit = new DateTime(2022, 01, 15),
                AnimalId = 2,
                VetId = "f91df8ac-13a9-49bd-9096-6141970e00ee",
                Diagnosis = "-",
                RecipeId = null,
                Comments = "Первый визит к доктору, прием",
                Cost = 150.0M
            };
            Visit visit3 = new Visit
            {
                Id = 3,
                DateVisit = new DateTime(2022, 02, 16),
                AnimalId = 3,
                VetId = "f91df8ac-13a9-49bd-9096-6141970e00ee",
                Diagnosis = "-",
                RecipeId = null,
                Comments = "Первый визит к доктору, прием",
                Cost = 150.0M
            };
            Visit visit4 = new Visit
            {
                Id = 4,
                DateVisit = new DateTime(2022, 03, 16),
                AnimalId = 4,
                VetId = "f91df8ac-13a9-49bd-9096-6141970e00ee",
                Diagnosis = "-",
                RecipeId = null,
                Comments = "Первый визит к доктору, прием",
                Cost = 150.0M
            };
            Visit visit5 = new Visit
            {
                Id = 5,
                DateVisit = new DateTime(2022, 03, 16),
                AnimalId = 5,
                VetId = "f91df8ac-13a9-49bd-9096-6141970e00ee",
                Diagnosis = "-",
                RecipeId = null,
                Comments = "Первый визит к доктору, прием",
                Cost = 150.0M
            };

            _visits = new List<Visit>();
            _visits.Add(visit1);
            _visits.Add(visit2);
            _visits.Add(visit3);
            _visits.Add(visit4);
            _visits.Add(visit5);
            #endregion
        }
        public void AddVisit(Visit visit)
        {
            if (visit == null)
                throw new ArgumentNullException("visit is null");

            _visits.Add(visit);
        }

        public Visit GetVisit(int id)
        {
            return _visits.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Visit> GetVisits()
        {
            return _visits;
        }

        public IEnumerable<Visit> GetVisitsFilter(string vetId, DateTime startDate, DateTime endDate)
        {
            return _visits.Where(x => 
                x.DateVisit >= startDate && 
                x.DateVisit <= endDate && 
                x.VetId == vetId);
        }
    }
}
