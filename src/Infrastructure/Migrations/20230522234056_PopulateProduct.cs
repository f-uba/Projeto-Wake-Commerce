using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Stock", "Value"},
                values: new object[,]
                {
                    { Guid.NewGuid().ToString(), "H20", 5, 5.99 },
                    { Guid.NewGuid().ToString(), "7up", 22, 6.89 },
                    { Guid.NewGuid().ToString(), "Fanta", 23, 7.19 },
                    { Guid.NewGuid().ToString(), "Pepsi", 34, 6.99 },
                    { Guid.NewGuid().ToString(), "Coca-Cola", 20, 7.89 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
