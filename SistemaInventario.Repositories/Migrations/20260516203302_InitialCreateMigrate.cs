using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "StockMinimo",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "AlmacenId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventarioAlmacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioAlmacenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioAlmacenes_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioAlmacenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_AlmacenId",
                table: "Movimientos",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioAlmacenes_AlmacenId",
                table: "InventarioAlmacenes",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioAlmacenes_ProductoId",
                table: "InventarioAlmacenes",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Almacenes_AlmacenId",
                table: "Movimientos",
                column: "AlmacenId",
                principalTable: "Almacenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Almacenes_AlmacenId",
                table: "Movimientos");

            migrationBuilder.DropTable(
                name: "InventarioAlmacenes");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_AlmacenId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "AlmacenId",
                table: "Movimientos");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMinimo",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
