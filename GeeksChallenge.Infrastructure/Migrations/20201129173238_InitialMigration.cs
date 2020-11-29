using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeeksChallenge.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CloudProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infrastructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CloudProviderId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infrastructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infrastructures_CloudProviders_CloudProviderId",
                        column: x => x.CloudProviderId,
                        principalTable: "CloudProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOptions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfrastructureId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureResource_Infrastructures_InfrastructureId",
                        column: x => x.InfrastructureId,
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureResource_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionDefaultValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceOptionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionDefaultValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionDefaultValues_ServiceOptions_ServiceOptionId",
                        column: x => x.ServiceOptionId,
                        principalTable: "ServiceOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureResourceOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfrastructureResourceId = table.Column<int>(type: "int", nullable: false),
                    ServiceOptionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureResourceOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureResourceOptions_InfrastructureResource_InfrastructureResourceId",
                        column: x => x.InfrastructureResourceId,
                        principalTable: "InfrastructureResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureResourceOptions_ServiceOptions_ServiceOptionId",
                        column: x => x.ServiceOptionId,
                        principalTable: "ServiceOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CloudProviders",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Name", "UpdatedById", "UpdatedDate" },
                values: new object[] { 1, -1, new DateTime(2020, 11, 29, 19, 32, 37, 623, DateTimeKind.Local).AddTicks(1287), null, null, "IGS", null, null });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Name", "UpdatedById", "UpdatedDate" },
                values: new object[] { 1, -1, new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(778), null, null, "Virtual Machines", null, null });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Name", "UpdatedById", "UpdatedDate" },
                values: new object[] { 2, -1, new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(854), null, null, "Database Servers", null, null });

            migrationBuilder.InsertData(
                table: "ServiceOptions",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Name", "ServiceId", "UpdatedById", "UpdatedDate" },
                values: new object[] { 1, -1, new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(6762), null, null, "Operating System", 1, null, null });

            migrationBuilder.InsertData(
                table: "ServiceOptions",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Name", "ServiceId", "UpdatedById", "UpdatedDate" },
                values: new object[] { 2, -1, new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(6847), null, null, "Database Engine", 2, null, null });

            migrationBuilder.InsertData(
                table: "OptionDefaultValues",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "OptionValue", "ServiceOptionId", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, -1, new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1427), null, null, "Windows", 1, null, null },
                    { 2, -1, new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1488), null, null, "Linux", 1, null, null },
                    { 3, -1, new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1490), null, null, "MySQL ", 2, null, null },
                    { 4, -1, new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1491), null, null, " SQL Server ", 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResource_InfrastructureId",
                table: "InfrastructureResource",
                column: "InfrastructureId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResource_ServiceId",
                table: "InfrastructureResource",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResourceOptions_InfrastructureResourceId",
                table: "InfrastructureResourceOptions",
                column: "InfrastructureResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResourceOptions_ServiceOptionId",
                table: "InfrastructureResourceOptions",
                column: "ServiceOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Infrastructures_CloudProviderId",
                table: "Infrastructures",
                column: "CloudProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionDefaultValues_ServiceOptionId",
                table: "OptionDefaultValues",
                column: "ServiceOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOptions_ServiceId",
                table: "ServiceOptions",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfrastructureResourceOptions");

            migrationBuilder.DropTable(
                name: "OptionDefaultValues");

            migrationBuilder.DropTable(
                name: "InfrastructureResource");

            migrationBuilder.DropTable(
                name: "ServiceOptions");

            migrationBuilder.DropTable(
                name: "Infrastructures");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "CloudProviders");
        }
    }
}
