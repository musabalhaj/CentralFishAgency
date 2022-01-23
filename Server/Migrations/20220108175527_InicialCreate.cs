using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectX.Server.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BoatCaptain = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                });

            migrationBuilder.CreateTable(
                name: "Fishs",
                columns: table => new
                {
                    FishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishs", x => x.FishId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatLoads",
                columns: table => new
                {
                    BoatLoadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatId = table.Column<int>(type: "int", nullable: false),
                    LoadDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatLoads", x => x.BoatLoadId);
                    table.ForeignKey(
                        name: "FK_BoatLoads_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseBatchs",
                columns: table => new
                {
                    PurchaseBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    BoatLoadId = table.Column<int>(type: "int", nullable: false),
                    BoatLoadDetailsId = table.Column<int>(type: "int", nullable: false),
                    FishId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBatchs", x => x.PurchaseBatchId);
                    table.ForeignKey(
                        name: "FK_PurchaseBatchs_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    PurchaseDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.PurchaseDetailsId);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Fishs_FishId",
                        column: x => x.FishId,
                        principalTable: "Fishs",
                        principalColumn: "FishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatLoadDetails",
                columns: table => new
                {
                    BoatLoadDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatLoadId = table.Column<int>(type: "int", nullable: false),
                    FishId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatLoadDetails", x => x.BoatLoadDetailsId);
                    table.ForeignKey(
                        name: "FK_BoatLoadDetails_BoatLoads_BoatLoadId",
                        column: x => x.BoatLoadId,
                        principalTable: "BoatLoads",
                        principalColumn: "BoatLoadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatLoadDetails_Fishs_FishId",
                        column: x => x.FishId,
                        principalTable: "Fishs",
                        principalColumn: "FishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "AgentId", "AgentAddress", "AgentEmail", "AgentName", "AgentPhone" },
                values: new object[,]
                {
                    { 1, "Agent 1 Address", "Agent1@gmail.com", "Agent 1", "0995514212" },
                    { 2, "Agent 2 Address", "Agent2@gmail.com", "Agent 2", "0995514212" },
                    { 3, "Agent 3 Address", "Agent3@gmail.com", "Agent 3", "0995514212" }
                });

            migrationBuilder.InsertData(
                table: "Boats",
                columns: new[] { "BoatId", "BoatCaptain", "BoatName" },
                values: new object[,]
                {
                    { 1, "Captain 1", "Boat 1" },
                    { 2, "Captain 2", "Boat 2" },
                    { 3, "Captain 3", "Boat 3" }
                });

            migrationBuilder.InsertData(
                table: "Fishs",
                columns: new[] { "FishId", "FishName", "Quantity" },
                values: new object[,]
                {
                    { 1, "Tilapia", 100 },
                    { 2, "Mackerel", 100 },
                    { 3, "Grouper", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatLoadDetails_BoatLoadId",
                table: "BoatLoadDetails",
                column: "BoatLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatLoadDetails_FishId",
                table: "BoatLoadDetails",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatLoads_BoatId",
                table: "BoatLoads",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchs_PurchaseOrderId",
                table: "PurchaseBatchs",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_FishId",
                table: "PurchaseDetails",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseOrderId",
                table: "PurchaseDetails",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_AgentId",
                table: "PurchaseOrders",
                column: "AgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatLoadDetails");

            migrationBuilder.DropTable(
                name: "PurchaseBatchs");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "BoatLoads");

            migrationBuilder.DropTable(
                name: "Fishs");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
