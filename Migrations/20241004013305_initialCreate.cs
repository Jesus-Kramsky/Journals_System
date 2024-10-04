using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journals_System.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    IdResearcher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchers", x => x.IdResearcher);
                });

            migrationBuilder.CreateTable(
                name: "JournalsFiles",
                columns: table => new
                {
                    IdJournal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdResearcher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalsFiles", x => x.IdJournal);
                    table.ForeignKey(
                        name: "FK_JournalsFiles_Researchers_IdResearcher",
                        column: x => x.IdResearcher,
                        principalTable: "Researchers",
                        principalColumn: "IdResearcher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    IdSubscriptions = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    FollowedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.IdSubscriptions);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Researchers_FollowedId",
                        column: x => x.FollowedId,
                        principalTable: "Researchers",
                        principalColumn: "IdResearcher",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Researchers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Researchers",
                        principalColumn: "IdResearcher",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalsFiles_IdResearcher",
                table: "JournalsFiles",
                column: "IdResearcher");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FollowedId",
                table: "Subscriptions",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriberId",
                table: "Subscriptions",
                column: "SubscriberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalsFiles");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Researchers");
        }
    }
}
