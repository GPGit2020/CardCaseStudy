using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityToolAPI.Migrations
{
    public partial class migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    AnnualSalary = table.Column<decimal>(type: "decimal", nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CardEligibilityDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserCardStatus = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    APROnCard = table.Column<decimal>(nullable: false),
                    UserPromotionalMsg = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEligibilityDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CardEligibilityDetail_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardEligibilityDetail_UserId",
                table: "CardEligibilityDetail",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardEligibilityDetail");

            migrationBuilder.DropTable(
                name: "UserDetail");
        }
    }
}
