using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiweb.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtmCadastro = table.Column<DateTime>(nullable: false),
                    BAtivo = table.Column<bool>(nullable: false),
                    SNome = table.Column<string>(nullable: false),
                    SEmail = table.Column<string>(nullable: false),
                    SAldeia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtmCadastro = table.Column<DateTime>(nullable: false),
                    BAtivo = table.Column<bool>(nullable: false),
                    DtmPedido = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    DValorPedido = table.Column<decimal>(nullable: false),
                    DDesconto = table.Column<decimal>(nullable: false),
                    DValorTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtmCadastro = table.Column<DateTime>(nullable: false),
                    BAtivo = table.Column<bool>(nullable: false),
                    SNome = table.Column<string>(nullable: false),
                    SDescricao = table.Column<string>(nullable: false),
                    DValor = table.Column<decimal>(nullable: false),
                    SPathFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Item = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductValorUn = table.Column<decimal>(nullable: false),
                    ProductQuantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.Item });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
