using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int Duration { get; set; }
        public string Treatment { get; set; }
    }
}
