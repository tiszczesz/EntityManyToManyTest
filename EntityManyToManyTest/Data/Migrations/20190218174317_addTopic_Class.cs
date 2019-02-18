using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityManyToManyTest.Data.Migrations
{
    public partial class addTopic_Class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassNameTopics",
                columns: table => new
                {
                    ClassNameId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassNameTopics", x => new { x.ClassNameId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_ClassNameTopics_ClassNames_ClassNameId",
                        column: x => x.ClassNameId,
                        principalTable: "ClassNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassNameTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassNameTopics_TopicId",
                table: "ClassNameTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassNameTopics");

            migrationBuilder.DropTable(
                name: "ClassNames");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
