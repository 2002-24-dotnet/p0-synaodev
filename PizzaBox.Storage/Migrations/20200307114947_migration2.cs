using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637190878846027450L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637190878846071969L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637190878846072003L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637190878846081234L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637190878846081559L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637190878846081573L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637190878846082174L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637190878846082438L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637190878846082455L);

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustID", "Name", "Price" },
                values: new object[,]
                {
                    { 637191569866182911L, "Deep Dish", 3.50m },
                    { 637191569866229976L, "New York Style", 2.50m },
                    { 637191569866230017L, "Thin Crust", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name", "Price" },
                values: new object[,]
                {
                    { 637191569866239946L, "Large", 12.00m },
                    { 637191569866240303L, "Medium", 10.00m },
                    { 637191569866240319L, "Small", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "Name", "Price" },
                values: new object[,]
                {
                    { 637191569866241316L, "Cheese", 0.25m },
                    { 637191569866241605L, "Pepperoni", 0.50m },
                    { 637191569866241619L, "Tomato Sauce", 0.75m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637191569866182911L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637191569866229976L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "CrustID",
                keyValue: 637191569866230017L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637191569866239946L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637191569866240303L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 637191569866240319L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637191569866241316L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637191569866241605L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 637191569866241619L);

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustID", "Name", "Price" },
                values: new object[,]
                {
                    { 637190878846027450L, "Deep Dish", 3.50m },
                    { 637190878846071969L, "New York Style", 2.50m },
                    { 637190878846072003L, "Thin Crust", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name", "Price" },
                values: new object[,]
                {
                    { 637190878846081234L, "Large", 12.00m },
                    { 637190878846081559L, "Medium", 10.00m },
                    { 637190878846081573L, "Small", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "Name", "Price" },
                values: new object[,]
                {
                    { 637190878846082174L, "Cheese", 0.25m },
                    { 637190878846082438L, "Pepperoni", 0.50m },
                    { 637190878846082455L, "Tomato Sauce", 0.75m }
                });
        }
    }
}
