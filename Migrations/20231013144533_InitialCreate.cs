using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security_Principles_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityPrinciples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    principleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displayName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityPrinciples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    groupId = table.Column<int>(type: "int", nullable: false),
                    securityPrincipleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => new { x.groupId, x.securityPrincipleId });
                    table.ForeignKey(
                        name: "FK_GroupMembers_SecurityPrinciples_groupId",
                        column: x => x.groupId,
                        principalTable: "SecurityPrinciples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityPrinciples_displayName",
                table: "SecurityPrinciples",
                column: "displayName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "SecurityPrinciples");
        }
    }
}
