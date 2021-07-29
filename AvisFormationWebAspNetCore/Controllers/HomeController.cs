using AvisFormationWebAspNetCore.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationWebAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        IFormationRepository _repository;
        public HomeController(IFormationRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Index()
        {

            //FormationMemoryRepository repository = new FormationMemoryRepository();
            var listFormations = _repository.GetFormations(4);
            var vm = new List<DetailFormationViewModel>();
            foreach (var f in listFormations)
            {
                vm.Add(new DetailFormationViewModel
                {
                    Formation = f,
                    NoteMoyenne = Math.Round(f.Avis.Select(a => a.Note).DefaultIfEmpty(0).Average(),1)
            });
            }

            return View(vm);
        }
    }
}
