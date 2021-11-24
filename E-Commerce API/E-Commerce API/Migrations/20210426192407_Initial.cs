using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrontCameras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontCameras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpSystems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpSystems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RearCameras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RearCameras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StyleJoins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleJoins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submenus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    MenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Submenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SubMenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Brands_Submenus_SubMenuID",
                        column: x => x.SubMenuID,
                        principalTable: "Submenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    MainImage = table.Column<string>(maxLength: 200, nullable: false),
                    MenuID = table.Column<int>(nullable: false),
                    SubmenuTitleID = table.Column<int>(nullable: false),
                    SubmenuID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    OpSystemID = table.Column<int>(nullable: false),
                    ProcessorID = table.Column<int>(nullable: false),
                    RAMID = table.Column<int>(nullable: false),
                    StorageID = table.Column<int>(nullable: false),
                    SSDID = table.Column<int>(nullable: false),
                    GraphicsCardID = table.Column<int>(nullable: false),
                    StyleJoinID = table.Column<int>(nullable: false),
                    FrontCameraID = table.Column<int>(nullable: false),
                    RearCameraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_FrontCameras_FrontCameraID",
                        column: x => x.FrontCameraID,
                        principalTable: "FrontCameras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_GraphicsCards_GraphicsCardID",
                        column: x => x.GraphicsCardID,
                        principalTable: "GraphicsCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_OpSystems_OpSystemID",
                        column: x => x.OpSystemID,
                        principalTable: "OpSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Processors_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "Processors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_RAMs_RAMID",
                        column: x => x.RAMID,
                        principalTable: "RAMs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_RearCameras_RearCameraID",
                        column: x => x.RearCameraID,
                        principalTable: "RearCameras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SSDs_SSDID",
                        column: x => x.SSDID,
                        principalTable: "SSDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Storages_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_StyleJoins_StyleJoinID",
                        column: x => x.StyleJoinID,
                        principalTable: "StyleJoins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pictures_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SubMenuID",
                table: "Brands",
                column: "SubMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductID",
                table: "Pictures",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorID",
                table: "Products",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FrontCameraID",
                table: "Products",
                column: "FrontCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GraphicsCardID",
                table: "Products",
                column: "GraphicsCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OpSystemID",
                table: "Products",
                column: "OpSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProcessorID",
                table: "Products",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RAMID",
                table: "Products",
                column: "RAMID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RearCameraID",
                table: "Products",
                column: "RearCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SSDID",
                table: "Products",
                column: "SSDID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageID",
                table: "Products",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StyleJoinID",
                table: "Products",
                column: "StyleJoinID");

            migrationBuilder.CreateIndex(
                name: "IX_Submenus_MenuID",
                table: "Submenus",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "FrontCameras");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "OpSystems");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "RAMs");

            migrationBuilder.DropTable(
                name: "RearCameras");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "StyleJoins");

            migrationBuilder.DropTable(
                name: "Submenus");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
