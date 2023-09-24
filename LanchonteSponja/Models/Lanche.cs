using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchonteSponja.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }//coluna da primary Key
        //Atributos => Nome
        [Required(ErrorMessage ="O nome do Lanche deve ser informado")]
        [Display(Name ="Nome do Lanche")]
        [StringLength(80,MinimumLength =10,ErrorMessage ="O {0} deve ter no minimo {1} e no maximo{2}")]
        public string Nome { get; set; }
        //Atributos=>DescriçãoCurta
        [Required(ErrorMessage = "A Descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "A Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(200,ErrorMessage ="Descrição pode exceder {1} caracteres")]
        public  string DescricaoCurta { get; set; }
        //Atributos =>Descrição DETALHADA
        [Required(ErrorMessage = "A Descrição detalhada do Lanche deve ser informado")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "A Descrição detalhada deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        //ATRIBUTO => PREÇO
        [Required(ErrorMessage ="Informe o Preço do Lanche")]
        [Display(Name="Preço")]
        [Column(TypeName="decimal(10,2)")]//10 digitos com precisão de 2 casas decimais
        [Range(1,999.99,ErrorMessage ="O Preço deve esta entre $1 real e $999.99 reais")]
        public decimal Preco { get; set; }
        //ATRIBUTO=> IMAGEM URL
        [Display(Name ="Caminho Imagem Normal")]
        [StringLength(200,ErrorMessage ="O {0} deve ter no maximo {1} caracteres")]
        public string ImgagemUrl { get; set; }
        //ATRIBUTO=>Imagem miniatura(pequena)
        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1} caracteres")]
        public string ImagemThumbnaiUrl { get; set;}//imagem miniatura
        //ATRIBUTO=> Lanche preferido
        [Display(Name ="Preferido?")]

        public bool IsLanchePreferido { get; set; }
        //ATRIBUTO=> ESTOQUE
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }
        //ABAIXO PROPRIEDADES DE NAVEGAÇÃO APENAS
        public int  CategoriaId { get; set; }//mapeado como chave estrangeira //

        public virtual Categoria Categoria { get; set; }//IRA DEFINIR O RELACIONAMENTO COM TABELA LANCHE

    }
}
