using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CatalogoBD.Produtos;

namespace CatalogoBD
{
    public class Categorias
    {
        [Table("Categorias")]
        public class Categoria
        {
            public Categoria()
            {
                Produtos = new Collection<Produtos>();
            }

            [Key]
            public int CategoriaId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Nome { get; set; }

            [Required]
            [MaxLength(300)]
            public string ImgURL { get; set; }

            public ICollection<Produtos> Produtos { get; set; }
        }
    }
}
