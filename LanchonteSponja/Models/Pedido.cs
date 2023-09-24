using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchonteSponja.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId {  get; set; }//chave key
        //1º Nome
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]
        

        public string Nome { get; set; }//nome
        //2º SobreNome
        [Required(ErrorMessage = "Informe o Sobrenome")]
        [StringLength(50)]
      
        public string Sobrenome { get; set; }//sobrenome
        //3º endereço
        [Required(ErrorMessage = "Informe o seu endereço")]
        [StringLength(100)]
        [Display(Name ="Endereço")]
       
        public string Endereco1 { get; set; }//endereço
        //4º complemento do endereço
        [StringLength(100)]
        [Display(Name = "Complemento")]
        
        public string Endereco2 { get; set; }//complemento
        //5º CEP DO ENDEREÇO
        [Required(ErrorMessage ="Informe o seu CEP")]
        [Display(Name ="CEP")]
        [StringLength (10,MinimumLength =8)]
        public string Cep { get; set; }//CEP

        [StringLength(10)]
        public string Estado { get; set; }
        //6ºCIDADE
        [StringLength(50)]
        public string Cidade { get; set; }//CIDADE
        //7º TELEFONE
        [Required(ErrorMessage ="Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }//TELEFONE

        //8º EMAIL DO CLIENTE
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public string  Email { get; set; }//email

        //9º PEDIDO TOTAL
        [ScaffoldColumn(false)]
        [Column(TypeName="decimal(18,2)")]
        [Display(Name ="Total do pedido")]
        public decimal PedidoTotal { get; set; }// Pedido total

        //10º TOTAL DOS ITENS PEDIDOS
        [ScaffoldColumn(false)]
        [Display(Name = "Itens do pedido")]

        public int TotalItensPedido {  get; set; }//Total dos itens pedidos
        //11º PEDIDO ENVIADO
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; } // PEDIDO ENVIADO
        //12º PEDIDO ENTREGUE
        [Display(Name = "Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }//PEDIDO ENTREGUE



        public List<PedidoDetalhe> PedidoItens { get; set; }

    }
}
