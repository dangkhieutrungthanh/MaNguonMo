using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet.Migrations
{
    public partial class Update_Table_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_KhachHangId",
                table: "HoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "KhachHangId",
                table: "KhachHang",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "khachHangsKhachHangId",
                table: "HoaDon",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_khachHangsKhachHangId",
                table: "HoaDon",
                column: "khachHangsKhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_khachHangsKhachHangId",
                table: "HoaDon",
                column: "khachHangsKhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_khachHangsKhachHangId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_khachHangsKhachHangId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "khachHangsKhachHangId",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "KhachHang",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_KhachHangId",
                table: "HoaDon",
                column: "KhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
