using LanchonteSponja.Context;
using LanchonteSponja.Models;
using LanchonteSponja.Repositories.Interfaces;

namespace LanchonteSponja.Repositories
{//REPOSITORIO PARA CATEGORIA
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly AppDbContext _context;
        //construtor gerado abaixo
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;//acessar tabela categorias e retornar a coleção de categorias
    }

}
