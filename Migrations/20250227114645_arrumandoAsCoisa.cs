using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoAsCoisa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ClientId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BebidaOrder");

            migrationBuilder.DropTable(
                name: "IngredienteLanche");

            migrationBuilder.DropTable(
                name: "LancheOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "BebidasId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FinalOrderId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LanchesId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LancheId1",
                table: "Ingredientes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Ingredientes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId1",
                table: "Ingredientes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinalOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalOrder_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BebidasId",
                table: "Orders",
                column: "BebidasId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FinalOrderId",
                table: "Orders",
                column: "FinalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanchesId",
                table: "Orders",
                column: "LanchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_LancheId1",
                table: "Ingredientes",
                column: "LancheId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_OrderId",
                table: "Ingredientes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_OrderId1",
                table: "Ingredientes",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrder_ClientId",
                table: "FinalOrder",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Lanches_LancheId1",
                table: "Ingredientes",
                column: "LancheId1",
                principalTable: "Lanches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Orders_OrderId",
                table: "Ingredientes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Orders_OrderId1",
                table: "Ingredientes",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bebidas_BebidasId",
                table: "Orders",
                column: "BebidasId",
                principalTable: "Bebidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FinalOrder_FinalOrderId",
                table: "Orders",
                column: "FinalOrderId",
                principalTable: "FinalOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Lanches_LanchesId",
                table: "Orders",
                column: "LanchesId",
                principalTable: "Lanches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Lanches_LancheId1",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Orders_OrderId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Orders_OrderId1",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bebidas_BebidasId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FinalOrder_FinalOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Lanches_LanchesId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FinalOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BebidasId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FinalOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LanchesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_LancheId1",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_OrderId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_OrderId1",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "BebidasId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FinalOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LanchesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LancheId1",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Ingredientes");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BebidaOrder",
                columns: table => new
                {
                    BebidasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BebidaOrder", x => new { x.BebidasId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_BebidaOrder_Bebidas_BebidasId",
                        column: x => x.BebidasId,
                        principalTable: "Bebidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BebidaOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteLanche",
                columns: table => new
                {
                    IngredientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LancheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteLanche", x => new { x.IngredientesId, x.LancheId });
                    table.ForeignKey(
                        name: "FK_IngredienteLanche_Ingredientes_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteLanche_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LancheOrder",
                columns: table => new
                {
                    LanchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancheOrder", x => new { x.LanchesId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_LancheOrder_Lanches_LanchesId",
                        column: x => x.LanchesId,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancheOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BebidaOrder_OrderId",
                table: "BebidaOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteLanche_LancheId",
                table: "IngredienteLanche",
                column: "LancheId");

            migrationBuilder.CreateIndex(
                name: "IX_LancheOrder_OrderId",
                table: "LancheOrder",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
