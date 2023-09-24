using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace LanchonteSponja.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key] 
        public int CategoriaId { get; set; }//coluna da primary Key

        //1º ATRIBUTOS para propriedade CategoriaNome
        [StringLength(100,ErrorMessage ="O tamanho maximo é 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome da Categoria")]
        [Display(Name ="Nome")]
        public string   CategoriaNome { get; set; }
        //2ºATRIBUTOS para categoria descricao
        [StringLength(200, ErrorMessage = "O tamanho maximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe a Descrição da Categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //denifir uma categoria de um para muitos muito -< (relacionamento)
        public List<Lanche> Lanches { get; set;}

    }
}
