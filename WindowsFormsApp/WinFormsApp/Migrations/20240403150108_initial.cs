using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedDate", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(351), null, "One" },
                    { 2, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(373), null, "Two" },
                    { 3, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(377), null, "Three" },
                    { 4, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(385), null, "Four" },
                    { 5, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(388), null, "Five" },
                    { 6, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(391), null, "Six" },
                    { 7, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(395), null, "Seven" },
                    { 8, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(399), null, "Eight" },
                    { 9, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(402), null, "Nine" },
                    { 10, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(406), null, "Ten" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "CreatedDate", "DOB", "Gender", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1faedb18-a873-4529-8c06-3a0b61d3a1ae"), 2, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1133), new DateTime(2014, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Xander" },
                    { new Guid("5a446c50-89f3-466b-bba7-e65195eda4b4"), 8, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1192), new DateTime(2016, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Kayla" },
                    { new Guid("5fd4d018-805f-400e-8d60-6c38cf97c462"), 1, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1070), new DateTime(2010, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "John" },
                    { new Guid("6ed43c26-c94d-414f-b4b4-c2e6eaa52d57"), 5, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1099), new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Aaron" },
                    { new Guid("85e9fd7f-f827-404d-aad4-845c69c7e23f"), 4, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1172), new DateTime(2012, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Jane" },
                    { new Guid("ac37cbf6-d842-4ef6-ba73-5cb9739a4219"), 4, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1107), new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Aysha" },
                    { new Guid("d07eac83-6ec5-4af9-ae2b-6f26a6c3223d"), 7, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1086), new DateTime(2012, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Jamie" },
                    { new Guid("d8cb8acf-8e1b-4d1b-b8a3-f9e966a55b0f"), 6, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1120), new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Finch" },
                    { new Guid("e9a39d81-a58a-43fc-acb3-cc870791910b"), 2, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1160), new DateTime(2014, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Patricia" },
                    { new Guid("f4eee102-d6a5-46ae-969c-c2bb4b096c76"), 5, new DateTime(2024, 4, 3, 21, 1, 8, 360, DateTimeKind.Local).AddTicks(1184), new DateTime(2014, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Maria" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
