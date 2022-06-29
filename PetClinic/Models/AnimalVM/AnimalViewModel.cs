using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PetClinic.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Кличка")]
        public string Name { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirthday { get; set; }
        [Display(Name = "Дата регистрации")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Вес")]
        public double Weight { get; set; }
        [Display(Name = "Рост")]
        public double Height { get; set; }
        [Display(Name = "Вид животного")]
        public string TypeAnimal { get; set; }
        [Display(Name = "Порода/вид")]
        public string Breed { get; set; }
        [HiddenInput(DisplayValue=false)]
        public int OwnerId { get; set; }
    }
    public class RegisterAnimalViewModel
    {
        [Required]
        [Display(Name = "Кличка")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirthday { get; set; }
        [Required]
        [Display(Name = "Вес")]
        public double Weight { get; set; }
        [Required]
        [Display(Name = "Рост")]
        public double Height { get; set; }
        [Display(Name = "Вид животного")]
        public IEnumerable<SelectListItem> TypeAnimalList { get; set; }
        [HiddenInput(DisplayValue=false)]
        public int TypeAnimalId { get; set; }
        [Required]
        [Display(Name = "Порода/вид")]
        public string Breed { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int OwnerId { get; set; }
    }
}