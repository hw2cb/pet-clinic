using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetClinic.Models.HomeVM
{
    public class HomeViewModel
    {
        //PROFILE
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        //STATS
        [Display(Name = "Количество приемов на сегодня")]
        public int CountVisitToDay { get; set; }
        [Display(Name = "Список приемов")]
        public IEnumerable<VisitHomeViewModel> Visits { get; set; }




    }
}