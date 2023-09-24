using LanchonteSponja.Repositories;
using LanchonteSponja.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchonteSponja.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;
        
        //construtor
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        //construtor
        public IViewComponentResult Invoke()
        {
            //consulta linq
            var categorias = _categoriaRepository.Categorias.OrderBy(p => p.CategoriaNome);//busca na tabela base de dados categoria pelo nome
            return View(categorias);
        }
       
    }
}
