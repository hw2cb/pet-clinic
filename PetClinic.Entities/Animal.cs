using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public DateTime RegisterDate { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int TypeAnimalId { get; set; }
        public TypeAnimal TypeAnimal { get; set; }
        public string Breed { get; set; }
    }
}
