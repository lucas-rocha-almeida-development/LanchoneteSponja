using LanchonteSponja.Models;
using System.Data.SqlTypes;

namespace LanchonteSponja.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; } // somente leitura

    }
}
