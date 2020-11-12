using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPBackend.Migrations
{
    public partial class StandardProductNameUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StandardProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$64iAvlp7wjWhcJzfqjAkd.JB9s5CN37moN0mlu1or7/L2VvmoaXqG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$mfXWDVUTQnZyZE/NtgT5cOE.gejf4mAOgtNUCpDzkXq2B8TpTqUoO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$LK.8CBO8Vkxlu4sNTC7qIeuIkA3PrBblXvPCu2BuUfWki0IknH2MK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$moa8mhb50JQ14GoaRBg0j.6Est1XjuWjL0lMkZF7UVmPAQ94RQmJe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$jRC7CUpepfd2nCAoswxNQuUZSDLnaE7Y8xbSmSvlezWQ6lTqn.Jz6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StandardProducts",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U6Us.rSgKNQOdBGsOk/bGOc4Oa6bCczKrpq1N.N/JdmVNMRj3Yvse");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$f7ORw/Yv7RlriQ8749XzsexBdfDkA1EiK6Jv/yddlipQVllyCxDKG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$fxEnaNdioUn74.61AIFQy.C.jlWAp6XapPWfN.eeuDuPDhOOWMp8C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$NfMIvAqaxAGG2DupmOQSFOoANndQiEy.9j7vD4ZZYzRD5IPNuH14S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$cyzeXRjxn9ZAI5BWd7HJVuUnYcIk6M/H0O3d.46yIc4mr6lQb3cna");
        }
    }
}
