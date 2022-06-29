using AutoMapper;
using PetClinic.BLL.Interfaces;
using PetClinic.DTO;
using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        private IAnimalsService _animalsService;
        public AnimalController(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }
        // GET: Animal
        public async Task<ActionResult> Index()
        {
            var listAnimalsDTO = await _animalsService.GetAllAnimals();

            List<AnimalViewModel> animalViewModels = new List<AnimalViewModel>();

            for (int i = 0; i < listAnimalsDTO.Count(); i++)
            {
                animalViewModels.Add(
                    new AnimalViewModel
                    {
                        Id = listAnimalsDTO.ElementAt(i).Id,
                        Name = listAnimalsDTO.ElementAt(i).Name,
                        DateOfBirthday = listAnimalsDTO.ElementAt(i).DateOfBirthday,
                        RegisterDate = listAnimalsDTO.ElementAt(i).RegisterDate,
                        OwnerId = listAnimalsDTO.ElementAt(i).OwnerId,
                        Weight = listAnimalsDTO.ElementAt(i).Weight,
                        Height = listAnimalsDTO.ElementAt(i).Height,
                        TypeAnimal = listAnimalsDTO.ElementAt(i).TypeAnimal.Type,
                        Breed = listAnimalsDTO.ElementAt(i).Breed
                    });
            }

            return View(animalViewModels);
        }

        [HttpGet]
        public ActionResult CreateAnimal(int id)
        {
            RegisterAnimalViewModel vm = new RegisterAnimalViewModel();
            vm.OwnerId = id;
            //vm.TypeAnimalList = 
            return View();
        }
    }
}