using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPBackend.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 1,
                column: "Status",
                value: "Produced");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 2,
                column: "Status",
                value: "Produced");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 3,
                column: "Status",
                value: "Produced");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 4,
                column: "Status",
                value: "Produced");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$HIxaERy8ZGrEEGRnUKTRyu8N7pCJVahbRBw.UNX3GWldwB4Dfmtie");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$fkUqct2pB4oJjkQVdbLM0eSwq2yb3KKLrDtG.rn1NAoTvDTBnponW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$tapGOoNUWrYO9pfwY3tTgODwqKw84qdR90OFEjqAa9EUhrHh08KsS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$dtXeuV.wySZJKLNEKp93zOo2qmMe1JGeqCdZ9BQgW9bpvE6qkp.7u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$dVY.L7cHk.kj/KSX/Af4X.mKnhfIjiYnkDwmN3NDutqv5Mwzxupdu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 1,
                column: "Status",
                value: "InProduction");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 2,
                column: "Status",
                value: "InProduction");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 3,
                column: "Status",
                value: "InProduction");

            migrationBuilder.UpdateData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 4,
                column: "Status",
                value: "InProduction");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7lfhYYnX2SW2JNKhMnjO9ObqUvWlilxA.xmw0wZyqS.bGdrqqRG5q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$tpRNnkfzErWzP/bwhGGy/.C.VdwoIBgCjpYz/WISWlTu0IC62SKo2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$gi0KZhxVgJDeMG32Iy/6M.DMz4FnmvwYyzDs/jENr4CjkkA6Mx8Rm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$z0xh/Fl2EoL5OReqxoe0WuvOb4qJ90gTMSOlAfKr9w/JN8gruLSjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Kdmc41EhlQvrxaTfQof29OmC0HS8IW8C3LbtxrPYw/v9b2lK/YWRe");
        }
    }
}
