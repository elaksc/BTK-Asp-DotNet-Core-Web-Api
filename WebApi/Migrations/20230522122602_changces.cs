using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class changces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3508d20e-8d2c-4829-93be-f37201ad5b9c", "0abc2c74-852c-43c2-b670-bdd216ecfe52", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a9ac2e5-9412-4bff-8412-37376d9d2332", "293677d5-0525-4f01-a50a-77981187d494", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a072d84a-342d-4b88-b6fb-4ffc5957d254", "dc2e7029-06cf-46eb-b566-3fdad9c4a966", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3508d20e-8d2c-4829-93be-f37201ad5b9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a9ac2e5-9412-4bff-8412-37376d9d2332");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a072d84a-342d-4b88-b6fb-4ffc5957d254");

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
    }
}
