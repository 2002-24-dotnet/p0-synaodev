using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CrustID = table.Column<long>(nullable: true),
                    SizeID = table.Column<long>(nullable: true),
                    ToppingID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustID);
                    table.ForeignKey(
                        name: "FK_Crusts_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                    table.ForeignKey(
                        name: "FK_Sizes_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustID", "Name", "PizzaID", "Price" },
                values: new object[,]
                {
                    { 637190312766192406L, "Deep Dish", null, 3.50m },
                    { 637190312766237511L, "New York Style", null, 2.50m },
                    { 637190312766237547L, "Thin Crust", null, 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name", "PizzaID", "Price" },
                values: new object[,]
                {
                    { 637190312766246539L, "Large", null, 12.00m },
                    { 637190312766246837L, "Medium", null, 10.00m },
                    { 637190312766246850L, "Small", null, 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "Name", "PizzaID", "Price" },
                values: new object[,]
                {
                    { 637190312766247497L, "Cheese", null, 0.25m },
                    { 637190312766247754L, "Pepperoni", null, 0.50m },
                    { 637190312766247770L, "Tomato Sauce", null, 0.75m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_PizzaID",
                table: "Crusts",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustID",
                table: "Pizzas",
                column: "CrustID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeID",
                table: "Pizzas",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingID",
                table: "Pizzas",
                column: "ToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_PizzaID",
                table: "Sizes",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaID",
                table: "Toppings",
                column: "PizzaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustID",
                table: "Pizzas",
                column: "CrustID",
                principalTable: "Crusts",
                principalColumn: "CrustID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeID",
                table: "Pizzas",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingID",
                table: "Pizzas",
                column: "ToppingID",
                principalTable: "Toppings",
                principalColumn: "ToppingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_Pizzas_PizzaID",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Pizzas_PizzaID",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaID",
                table: "Toppings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
