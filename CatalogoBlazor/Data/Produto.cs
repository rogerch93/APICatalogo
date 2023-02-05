using System.ComponentModel.DataAnnotations;
using System;

namespace CatalogoBlazor.Data
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ImgURL { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        //    public Categoria Categoria { get; set; }
        //    public int CategoriaId { get; set; }
    }
}
