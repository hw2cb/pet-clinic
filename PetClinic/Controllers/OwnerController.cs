using PetClinic.BLL.Interfaces;
using PetClinic.DTO;
using PetClinic.Models.OwnerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Controllers
{
    public class OwnerController : Controller
    {
        private IOwnersService _ownersService;
        public OwnerController(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOwner()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateOwner(RegisterOwnerViewModel model)
        {

            if(ModelState.IsValid)
            {
                OwnerDTO ownerDTO = new OwnerDTO
                {
                    Name = model.NameOwner,
                    Surname = model.Surname,
                    Phone = model.Phone
                };
                int idOwner = await _ownersService.UpsertOwner(ownerDTO);
                return RedirectToAction("CreateAnimal", "Animal", new {idOwner});
            }
            return View(model);

        }
    }
}