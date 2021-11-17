using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet.Migrations
{
    public partial class Create_Table_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Student",
                newName: "Universisty");

            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "People",
                newName: "PersonCode");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "People",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_People_PersonId",
                table: "Student",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_People_PersonId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.RenameColumn(
                name: "Universisty",
                table: "Student",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "PersonCode",
                table: "Person",
                newName: "PersonName");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PersonId",
                table: "Person",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");
        }
    }
}
