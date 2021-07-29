using AvisFormationWebAspNetCore.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationWebAspNetCore.Controllers
{
    public class FormationController : Controller
    {
        IFormationRepository _repository;
        public FormationController(IFormationRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var vm = new ToutesLesFormationViewModel();
            vm.Message = "Ceci est un message du controlleur";
            vm.Nombre = 93;

            // pas oublié de bien le mettre dans le return sinon message d'ereur
            // attention jamais mettre de double (pb avec la virgule) mettre des string
            return View(vm);
        }

        public IActionResult ToutesLesFormations()
        {
            //FormationMemoryRepository repository = new FormationMemoryRepository();
            var listFormations = _repository.GetAllFormations();
            var vm = new List<DetailFormationViewModel>();
            foreach (var formation in listFormations)
            {
                var temp = new DetailFormationViewModel();
                temp.Formation = formation;
                if (formation.Avis != null && formation.Avis.Count >0)
                {
                    temp.NoteMoyenne = Math.Round(formation.Avis.Select(a=>a.Note).ToList().Average(),1);
                }
                vm.Add(temp);
            }
            return View(vm);
        }

        public IActionResult DetailsFormation(string nomSeo)
        {
            var formation = _repository.GetFormationByNomSeo(nomSeo);
            if (formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            }
            var vm = new DetailFormationViewModel();
            vm.Formation = formation;
            if (formation.Avis != null && formation.Avis.Count >0)
            {
                vm.NoteMoyenne = Math.Round(formation.Avis.Select(a=>a.Note).ToList().Average(),1);
            }

            return View(vm);
        }






    }

}
