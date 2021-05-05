using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolSmukfest.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    FestivalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MembaNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailAlternate = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    CurrentSectionId = table.Column<int>(nullable: true),
                    VirtualMember = table.Column<bool>(nullable: false),
                    LastSynchronization = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    iscomplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    IsGroup = table.Column<bool>(nullable: false),
                    LastSynchronization = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FestivalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Section_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festival",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK_Events_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSupplier",
                columns: table => new
                {
                    ItemSupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSupplier", x => x.ItemSupplierId);
                    table.ForeignKey(
                        name: "FK_ItemSupplier_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeCategory",
                columns: table => new
                {
                    ItemTypeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeCategory", x => x.ItemTypeCategoryId);
                    table.ForeignKey(
                        name: "FK_ItemTypeCategory_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembaOrders",
                columns: table => new
                {
                    MembaOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CreatedByMemberId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembaOrders", x => x.MembaOrderId);
                    table.ForeignKey(
                        name: "FK_MembaOrders_Members_CreatedByMemberId",
                        column: x => x.CreatedByMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembaOrders_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembaOrders_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembaOrders_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ShortTitle = table.Column<string>(nullable: true),
                    ExternalSupplier = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PricePeriodUnit = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    ItemTypeCategoryId = table.Column<int>(nullable: true),
                    ItemSupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeId);
                    table.ForeignKey(
                        name: "FK_ItemType_ItemSupplier_ItemSupplierId",
                        column: x => x.ItemSupplierId,
                        principalTable: "ItemSupplier",
                        principalColumn: "ItemSupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemType_ItemTypeCategory_ItemTypeCategoryId",
                        column: x => x.ItemTypeCategoryId,
                        principalTable: "ItemTypeCategory",
                        principalColumn: "ItemTypeCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemType_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<int>(nullable: false),
                    Received = table.Column<DateTime>(nullable: true),
                    Returned = table.Column<DateTime>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Registration = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<int>(nullable: false),
                    ItemSupplierId = table.Column<int>(nullable: true),
                    ReceiverMemberId = table.Column<int>(nullable: true),
                    ReturnerMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemSupplier_ItemSupplierId",
                        column: x => x.ItemSupplierId,
                        principalTable: "ItemSupplier",
                        principalColumn: "ItemSupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Members_ReceiverMemberId",
                        column: x => x.ReceiverMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Members_ReturnerMemberId",
                        column: x => x.ReturnerMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembaOrderLines",
                columns: table => new
                {
                    MembaOrderLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    MembaOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembaOrderLines", x => x.MembaOrderLineId);
                    table.ForeignKey(
                        name: "FK_MembaOrderLines_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembaOrderLines_MembaOrders_MembaOrderId",
                        column: x => x.MembaOrderId,
                        principalTable: "MembaOrders",
                        principalColumn: "MembaOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembaOrderId = table.Column<int>(nullable: true),
                    MembaOrderLineId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    PickedUp = table.Column<DateTime>(nullable: true),
                    Returned = table.Column<DateTime>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    CreatedByMemberId = table.Column<int>(nullable: true),
                    CreatedByMemberMemberId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Members_CreatedByMemberId",
                        column: x => x.CreatedByMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Members_CreatedByMemberMemberId",
                        column: x => x.CreatedByMemberMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_MembaOrders_MembaOrderId",
                        column: x => x.MembaOrderId,
                        principalTable: "MembaOrders",
                        principalColumn: "MembaOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_MembaOrderLines_MembaOrderLineId",
                        column: x => x.MembaOrderLineId,
                        principalTable: "MembaOrderLines",
                        principalColumn: "MembaOrderLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CreatedByMemberId",
                table: "Booking",
                column: "CreatedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CreatedByMemberMemberId",
                table: "Booking",
                column: "CreatedByMemberMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ItemId",
                table: "Booking",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MembaOrderId",
                table: "Booking",
                column: "MembaOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MembaOrderLineId",
                table: "Booking",
                column: "MembaOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TeamId",
                table: "Booking",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProjectId",
                table: "Events",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemSupplierId",
                table: "Item",
                column: "ItemSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemTypeId",
                table: "Item",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ReceiverMemberId",
                table: "Item",
                column: "ReceiverMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ReturnerMemberId",
                table: "Item",
                column: "ReturnerMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_SectionId",
                table: "ItemSupplier",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_ItemSupplierId",
                table: "ItemType",
                column: "ItemSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_ItemTypeCategoryId",
                table: "ItemType",
                column: "ItemTypeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_SectionId",
                table: "ItemType",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeCategory_SectionId",
                table: "ItemTypeCategory",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrderLines_ItemTypeId",
                table: "MembaOrderLines",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrderLines_MembaOrderId",
                table: "MembaOrderLines",
                column: "MembaOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrders_CreatedByMemberId",
                table: "MembaOrders",
                column: "CreatedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrders_MemberId",
                table: "MembaOrders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrders_SectionId",
                table: "MembaOrders",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MembaOrders_TeamId",
                table: "MembaOrders",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_FestivalId",
                table: "Section",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ParentId",
                table: "Teams",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "MembaOrderLines");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "MembaOrders");

            migrationBuilder.DropTable(
                name: "ItemSupplier");

            migrationBuilder.DropTable(
                name: "ItemTypeCategory");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Festival");
        }
    }
}
