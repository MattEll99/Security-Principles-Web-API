using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security_Principles_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class vGroupMembersView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("create view vGroupMembers as\r\n" +
              "select g.groupId, g.securityPrincipleId as 'memberId', gsp.displayName as 'groupDisplayName', msp.displayName as 'memberDisplayName', msp.principleType as 'memberPrincipleType'\r\n" +
              "from GroupMembers g\r\n" +
              "inner join SecurityPrinciples gsp on gsp.Id = g.groupId\r\n" +
              "inner join SecurityPrinciples msp on msp.Id = g.securityPrincipleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW vGroupMembers;");
        }
    }
}
