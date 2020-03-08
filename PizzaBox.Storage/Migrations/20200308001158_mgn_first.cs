using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class mgn_first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CrustID = table.Column<long>(nullable: true),
                    SizeID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustID",
                        column: x => x.CrustID,
                        principalTable: "Crusts",
                        principalColumn: "CrustID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzaID = table.Column<long>(nullable: false),
                    ToppingID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzaID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
                        principalColumn: "ToppingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustID", "Name", "Price" },
                values: new object[,]
                {
                    { 637192015186097001L, "Deep Dish", 3.50m },
                    { 637192015186143946L, "New York Style", 2.50m },
                    { 637192015186144002L, "Thin Crust", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name", "Price" },
                values: new object[,]
                {
                    { 637192015186153543L, "Large", 12.00m },
                    { 637192015186154006L, "Medium", 10.00m },
                    { 637192015186154024L, "Small", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "Name", "Price" },
                values: new object[,]
                {
                    { 637192015186154697L, "Cheese", 0.25m },
                    { 637192015186154990L, "Pepperoni", 0.50m },
                    { 637192015186155002L, "Tomato Sauce", 0.75m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustID",
                table: "Pizzas",
                column: "CrustID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeID",
                table: "Pizzas",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingID",
                table: "PizzaTopping",
                column: "ToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
