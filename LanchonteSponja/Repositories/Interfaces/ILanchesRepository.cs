using LanchonteSponja.Models;

namespace LanchonteSponja.Repositories.Interfaces
{
    public interface ILancheRepository
    {//propriades somente para leitura e publicas
        IEnumerable<Lanche> Lanches { get; }//contrato para acessar todos os lanches
        IEnumerable <Lanche> LanchesPreferidos { get; } // contrato para acessar lanches preferidos

        //metodo para acessar um lanche pelo id ( lanche especifico busca pelo ID)
        Lanche GetLancheById(int LancheId);


    }
}
