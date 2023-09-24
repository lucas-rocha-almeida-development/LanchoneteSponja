using LanchonteSponja.Models;
using LanchonteSponja.Repositories;
using LanchonteSponja.Repositories.Interfaces;
using LanchonteSponja.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchonteSponja.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepository _lancherepository;
        //instancia do repositorio injetada
        //controlador criado para acessar uma instancia do meu repositorio
        public LancheController(ILancheRepository lancherepository)
        {
            _lancherepository = lancherepository;
        }

        //metodo para listar meus lanches 

        public IActionResult List(string categoria)
        {
            //retorno de lista de lanches um enumerable
            // ViewData["Titulo"] = "Todos os Lanches";
            // ViewData["Data"] = DateTime.Now;
            //var lanches = _lancherepository.Lanches;
            // var totalLanches = lanches.Count();

            // ViewBag.Total = "Total de Lanches: ";
            // ViewBag.TotalLanches = totalLanches;//IRA RETORNAR A QUANTIDADE DE LANCHES OBTIDOS NO COUNT
            // return View(lanches);
            //var lancheListViewModel = new LancheListViewModel();
            //lancheListViewModel.Lanches = _lancherepository.Lanches;
            //lancheListViewModel.CategoriaAtual = "Categoria Atual";
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            //caso o valor seja null ou vazio
            if(string.IsNullOrEmpty(categoria))
            {
                lanches = _lancherepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            //caso não seja verdade 
            else
            {
            //    if(string.Equals("Normal",categoria, StringComparison.OrdinalIgnoreCase))
            //    {//caso minha categoria seja normal 
            //        lanches = _lancherepository.Lanches
            //            .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
            //            .OrderBy(l => l.Nome);

            //    }
            //    else
            //    {
            //        lanches = _lancherepository.Lanches
            //            .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
            //            .OrderBy(l => l.Nome);
                
            //    }
            lanches = _lancherepository.Lanches
                .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel

            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };


            return View(lancheListViewModel);
        }
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancherepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);

        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancherepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches= _lancherepository.Lanches
                           .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
        }
    

