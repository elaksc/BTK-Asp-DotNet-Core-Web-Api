using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af41ad7-aa45-449a-83dc-9db1b98596fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64423d57-e668-4761-b091-56bfbdc456d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96a54673-d463-42fb-9fd2-331f07c5972b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31cb9731-4e8b-4e0d-bd76-f64e3e63960b", "14dd07d1-3b47-4559-8bbe-5d3303be69ab", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "989cd8da-52b7-4d5a-9c20-fd816d672fb2", "5933c7f3-97c6-4886-b949-e6bc35099196", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbd027a6-e678-483f-a673-41ce41ba75f8", "449c8140-1d6a-42e1-a4e0-02ceda00fce9", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31cb9731-4e8b-4e0d-bd76-f64e3e63960b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "989cd8da-52b7-4d5a-9c20-fd816d672fb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbd027a6-e678-483f-a673-41ce41ba75f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2af41ad7-aa45-449a-83dc-9db1b98596fd", "f58af644-34c0-4e13-bcea-d82420cbc251", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64423d57-e668-4761-b091-56bfbdc456d5", "2a709bb1-4b11-4851-9a79-560961f4b00d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96a54673-d463-42fb-9fd2-331f07c5972b", "0bcd28ff-604a-4169-97c4-c765e79b1b42", "USer", "USER" });
        }
    }
}
