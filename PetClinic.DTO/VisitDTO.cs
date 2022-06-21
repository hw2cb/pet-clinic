using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DTO
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public string VetId { get; set; }
        public DateTime DateVisit { get; set; }
        public AnimalDTO Animal { get; set; }
        public string Diagnosis { get; set; }
        public RecipeDTO Recipe { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}
