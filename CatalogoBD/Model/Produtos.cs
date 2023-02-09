using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CatalogoBD.Categorias;

namespace CatalogoBD
{
    [Table("Produtos")]
    public class Produtos
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
