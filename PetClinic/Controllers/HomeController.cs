using PetClinic.BLL.Interfaces;
using PetClinic.Models.HomeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetClinic.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IVisitsService _visitService;
        public HomeController(IVisitsService visitService)
        {
            _visitService = visitService;
        }
        //GET
        public async Task<ActionResult> Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            viewModel.Name = identity.Claims.Where(x => x.Type == "name").Select(x => x.Value).SingleOrDefault();
            viewModel.Surname = identity.Claims.Where(x => x.Type == "surname").Select(x => x.Value).SingleOrDefault();
            viewModel.Patronymic = identity.Claims.Where(x => x.Type == "patronymic").Select(x => x.Value).SingleOrDefault();
            //viewModel.Position = identity.Claims.Where(x => x.Type == "position").Select(x => x.Value).SingleOrDefault();
            viewModel.Position = "test";
            string id = identity.Claims.Where(x => x.Type == "id").Select(x => x.Value).SingleOrDefault();

            var visits = await _visitService.GetVisitsToDay(id);

            List<VisitHomeViewModel> visitVMs = new List<VisitHomeViewModel>();

            for(int i=0; i<visits.Count(); i++)
            {
                visitVMs.Add(new VisitHomeViewModel
                {
                    Id = visits.ElementAt(i).Id,
                    DateVisit = visits.ElementAt(i).DateVisit,
                    TypeAnimal = visits.ElementAt(i).Animal.TypeAnimal.Type,
                    Breed = visits.ElementAt(i).Animal.Breed
                });
            }
            viewModel.Visits = visitVMs;



            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}