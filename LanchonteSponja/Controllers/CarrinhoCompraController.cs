using LanchonteSponja.Models;
using Microsoft.AspNetCore.Mvc;
using LanchonteSponja.Repositories.Interfaces;
using LanchonteSponja.ViewModels;

namespace LanchonteSponja.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        //METODO DO IActionIndex
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;


            var carrinhoCompraVM = new CarrinhoCompraViewModel

            {
                CarrinhoCompra = _carrinhoCompra,//carrinho atual
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        //METODO ADICIONAR ITEM NO CARRINHO
        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)

        {
            //APLICAÇÃO METODO LINQ // EXPRESSÃO LAMBDA
             var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p=> p.LancheId == lancheId);

            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
               
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {//FirstORDefault retorna o primiero valor 
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

            }
            return RedirectToAction("Index");

        }
    }
}
