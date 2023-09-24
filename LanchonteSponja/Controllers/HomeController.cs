using LanchonteSponja.Models;
using LanchonteSponja.Repositories;
using LanchonteSponja.Repositories.Interfaces;
using LanchonteSponja.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchonteSponja.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
       

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            //TempData["Nome"] = "Lucas Almeida";
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }
        public IActionResult Demo()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}