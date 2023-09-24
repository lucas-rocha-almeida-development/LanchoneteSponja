using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchonteSponja.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {//propriedades que iram ser criadas para tabela
        [Key]
        public int CarinhoCompraItemId { get; set; }//id
        public Lanche Lanche { get; set; }//chave estrangeira
        public int Quantidade { get; set; }//quantidade dos lanches do usuario
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }//id do carrinho de compra ( identificar de forma unica)

    }
}
