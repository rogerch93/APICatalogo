using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

namespace APICatalogo.Migrations
{
    public partial class PopulaDb : Migration
    {

        
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, ImgUrl) " +
                "Values('Bebidas', 'https://images.unsplash.com/photo-1497534446932-c925b458314e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=472&q=80')");
            mb.Sql("INSERT INTO Categorias(Nome, ImgUrl) " +
                "Values('Lanches', 'https://images.unsplash.com/photo-1614891669421-964261109bb4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80')");
            mb.Sql("INSERT INTO Categorias(Nome, ImgUrl) " +
                "Values('Doces', 'https://images.unsplash.com/photo-1623888884234-cde757b501dc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80')");

            mb.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImgUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values('Vodka', 'Vodka Russa', 50.00, 'https://images.unsplash.com/photo-1613255347968-aa2aaa353976?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=726&q=80', '50', now()," +
                " (Select CategoriaId from Categorias where Nome = 'Bebidas'))");
            mb.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImgUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values('Vodka', 'X-Burger', 9.00, 'https://images.unsplash.com/photo-1614891669421-964261109bb4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80', '999', now()," +
                " (Select CategoriaId from Categorias where Nome = 'Lanches'))");
            mb.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImgUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values('Vodka', 'Bolo', 15.00, 'https://images.unsplash.com/photo-1623888884234-cde757b501dc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80', '8', now()," +
                " (Select CategoriaId from Categorias where Nome = 'Doces'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
