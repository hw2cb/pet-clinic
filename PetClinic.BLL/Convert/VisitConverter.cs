using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Convert
{
    public static class VisitConverter
    {
        public static VisitDTO ConvertToDTO(Visit visit)
        {
            VisitDTO visitDTO = new VisitDTO
            {
                Id = visit.Id,
                VetId = visit.VetId,
                DateVisit = visit.DateVisit,
                Diagnosis = visit.Diagnosis,
                Comments = visit.Comments,
                Cost = visit.Cost,
                Animal = AnimalConverter.ConvertToDTO(visit.Animal),
                Recipe = RecipeConverter.ConvertToDTO(visit.Recipe),
            };
            return visitDTO;
        }
        public static Visit ConvertFromDTO(VisitDTO visitDTO)
        {
            Visit visit = new Visit()
            {
                Id = visitDTO.Id,
                VetId = visitDTO.VetId,
                DateVisit = visitDTO.DateVisit,
                Diagnosis = visitDTO.Diagnosis,
                Comments = visitDTO.Comments,
                Cost = visitDTO.Cost,
                Animal = AnimalConverter.ConvertFromDTO(visitDTO.Animal),
                Recipe = RecipeConverter.ConvertFromDTO(visitDTO.Recipe),

            };
            return visit;
        }
    }
}
