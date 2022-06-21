using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Models.HomeVM
{
    public class VisitHomeViewModel
    {
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        [Display(Name="Дата приема")]
        public DateTime DateVisit { get; set; }
        [Display(Name ="Вид животного")]
        public string TypeAnimal { get; set; }
        [Display(Name = "Порода")]
        public string Breed { get; set; }
    }
}