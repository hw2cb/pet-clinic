using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetClinic.Models.OwnerVM
{
    public class RegisterOwnerViewModel
    {
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string NameOwner { get; set; }
        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}