using LanchonteSponja.Context;
using LanchonteSponja.Models;
using LanchonteSponja.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchonteSponja.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        

        private readonly AppDbContext _context;
        //1 obter instancia do contexto
        //fazer a injeção da Class AppBdContext
        public LancheRepository(AppDbContext contexto) {
        //construtor
        _context = contexto;
        
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
            Where(l=>l.IsLanchePreferido)
            .Include(c=>c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l=>l.LancheId == lancheId);
        }
    }
}
