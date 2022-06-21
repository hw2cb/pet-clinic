using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public string VetId { get; set; }
        public DateTime DateVisit { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Diagnosis { get; set; }
        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }

    }
}
