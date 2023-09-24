using LanchonteSponja.Models;
using LanchonteSponja.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchonteSponja.Controllers
{
    public class PedidoController : Controller
    {
        //injeção da instancia carrinhocompra // pedido
        //somente leitura

        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        //metodo IAction//formulario de validação para o cliente
        [HttpGet]
        public IActionResult Checkout()
        {//retorno da view 
            return View();

        }
        //Post // processamento
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {

            return View();
        }

    }
}
