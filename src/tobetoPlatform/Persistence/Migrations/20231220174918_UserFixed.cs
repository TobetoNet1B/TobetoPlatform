using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 26, 151, 233, 157, 90, 96, 105, 8, 250, 131, 42, 108, 242, 111, 60, 29, 174, 181, 153, 121, 170, 47, 68, 59, 31, 130, 183, 80, 10, 109, 148, 130, 102, 82, 5, 173, 234, 182, 31, 90, 255, 62, 124, 69, 246, 229, 144, 95, 174, 26, 186, 18, 249, 123, 31, 14, 180, 26, 19, 112, 205, 136, 180, 212 }, new byte[] { 29, 159, 237, 221, 10, 135, 125, 26, 81, 66, 197, 68, 88, 229, 221, 116, 209, 196, 83, 161, 37, 251, 93, 111, 118, 81, 137, 229, 54, 93, 111, 190, 121, 214, 151, 103, 92, 76, 0, 194, 114, 26, 229, 143, 109, 69, 172, 72, 0, 208, 198, 36, 179, 209, 7, 143, 87, 102, 213, 215, 85, 127, 21, 11, 171, 106, 132, 24, 42, 31, 5, 78, 89, 238, 203, 43, 196, 55, 30, 194, 77, 245, 105, 11, 45, 218, 66, 244, 12, 58, 181, 89, 172, 229, 164, 149, 57, 45, 172, 125, 155, 29, 168, 3, 192, 99, 177, 189, 52, 28, 186, 165, 211, 203, 1, 56, 85, 212, 161, 1, 2, 230, 33, 145, 239, 22, 119, 50 } });

            migrationBuilder.CreateIndex(
                name: "UK_Students_Name",
                table: "Students",
                column: "IdentityNumber",
                unique: true,
                filter: "[IdentityNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Students_Name",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 101, 209, 239, 118, 53, 144, 176, 216, 221, 250, 233, 67, 156, 68, 233, 209, 216, 172, 231, 111, 210, 165, 255, 14, 143, 212, 219, 149, 254, 240, 193, 135, 197, 86, 206, 135, 87, 238, 245, 52, 90, 136, 130, 140, 193, 255, 35, 1, 208, 62, 152, 10, 83, 158, 96, 58, 233, 175, 63, 39, 22, 10, 163, 207 }, new byte[] { 224, 30, 228, 127, 196, 128, 14, 31, 235, 6, 115, 222, 101, 7, 19, 72, 72, 45, 16, 205, 90, 37, 137, 143, 105, 62, 142, 35, 68, 56, 239, 121, 178, 81, 59, 203, 219, 142, 205, 238, 3, 13, 156, 12, 155, 95, 231, 253, 133, 247, 41, 199, 41, 237, 24, 11, 25, 80, 147, 128, 115, 116, 115, 145, 192, 83, 15, 209, 86, 134, 175, 239, 127, 182, 142, 98, 251, 204, 62, 125, 37, 151, 221, 113, 250, 231, 46, 89, 30, 88, 73, 188, 216, 6, 201, 245, 244, 74, 237, 40, 51, 10, 213, 242, 90, 127, 234, 80, 81, 71, 18, 225, 76, 191, 63, 76, 133, 88, 218, 120, 38, 19, 238, 60, 66, 9, 87, 233 } });
        }
    }
}
