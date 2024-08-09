using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyrus_Technology_Task.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Name", "MobileNumber" },
                values: new object[,]
                {
                    { 1, "User1", "11111111111" },
                    { 2, "User2", "22222222222" },
                    { 3, "User3", "33333333333" },
                    { 4, "User4", "44444444444" },
                    { 5, "User5", "55555555555" },
                    { 6, "User6", "66666666666" },
                    { 7, "User7", "77777777777" },
                    { 8, "User8", "88888888888" },
                    { 9, "User9", "99999999999" },
                    { 10, "User10", "10101010101" }
                }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AppUser]");
        }
    }
}
