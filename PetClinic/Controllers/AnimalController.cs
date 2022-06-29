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
        private ITypesAnimalService _typesAnimalService;
        public AnimalController(IAnimalsService animalsService, ITypesAnimalService typesAnimalService)
        {
            _animalsService = animalsService;
            _typesAnimalService = typesAnimalService;
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
        public async Task<ActionResult> CreateAnimal(int idOwner)
        {
            var typesAnimalFromDB = await _typesAnimalService.GetTypesAnimal();
            RegisterAnimalViewModel vm = new RegisterAnimalViewModel();
            vm.OwnerId = idOwner;
            vm.TypeAnimalList = typesAnimalFromDB.Select(i => new SelectListItem
            {
                Text = i.Type,
                Value = i.Id.ToString()
            });

            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAnimal(RegisterAnimalViewModel vm)
        {
            if(ModelState.IsValid)
            {
                AnimalDTO animalDTO = new AnimalDTO
                {
                    Name = vm.Name,
                    DateOfBirthday = vm.DateOfBirthday,
                    RegisterDate = DateTime.Now,
                    Weight = vm.Weight,
                    Height = vm.Height,
                    TypeAnimalId = vm.TypeAnimalId,
                    Breed = vm.Breed,
                    OwnerId = vm.OwnerId
                };
                await _animalsService.RegisterAnimal(animalDTO);
                return RedirectToAction("Index", "Home");
            }
            return View(vm);

        }
    }
}