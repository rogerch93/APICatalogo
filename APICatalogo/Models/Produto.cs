using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        [MaxLength(300)]
        public string ImgURL { get; set; }

        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
