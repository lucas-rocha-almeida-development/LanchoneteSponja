using LanchonteSponja.Models;

namespace LanchonteSponja.ViewModels
{
    //responsavel pela logica da VIEW
    public class HomeViewModel
    {
        //lista de lanches preferidos
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
