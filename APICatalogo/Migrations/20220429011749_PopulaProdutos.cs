using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) VALUES('Coca-Cola Diet', 'Refrigerante de Cola 350 ml', 5.45, 'cocacola.jpg', 50, now(),1)");
            migrationBuilder.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) VALUES('x-Salada', 'x-salada caseiro', 5.45, 'xsalada.jpg', 50, now(),2)");
            migrationBuilder.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) VALUES('Sorvete açai', 'Açai com qualquer acompanhamento', 5.45, 'acai.jpg', 50, now(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produto");
        }
    }
}
