using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Administration");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Contact");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "Sale");

            migrationBuilder.EnsureSchema(
                name: "Shopping");

            migrationBuilder.EnsureSchema(
                name: "Workflow");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactType = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flow",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowLog",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Log = table.Column<DateTime>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    EndStateId = table.Column<int>(nullable: false),
                    StartStateId = table.Column<int>(nullable: false),
                    TransitionId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Administration",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Administration",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Administration",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Administration",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Administration",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Administration",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Administration",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Administration",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Administration",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeRateDate = table.Column<DateTime>(nullable: false),
                    SaleRate = table.Column<decimal>(nullable: false),
                    PurchaseRate = table.Column<decimal>(nullable: false),
                    PrincipalCurrencyId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Common",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SaleUnitPrice = table.Column<decimal>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Shopping",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Common",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FlowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Flow_FlowId",
                        column: x => x.FlowId,
                        principalSchema: "Workflow",
                        principalTable: "Flow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StoreId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Workflow",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Common",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Common",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Workflow",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundle",
                schema: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Reference = table.Column<string>(nullable: true),
                    LocalTax = table.Column<decimal>(nullable: false),
                    LocalFreight = table.Column<decimal>(nullable: false),
                    ForeignTax = table.Column<decimal>(nullable: false),
                    ForeignFreight = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Order = table.Column<DateTime>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundle_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Common",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bundle_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Workflow",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transition",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StartStateId = table.Column<int>(nullable: false),
                    EndStateId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transition_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Workflow",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleQuota",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    SaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleQuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleQuota_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "Sale",
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BundleItem",
                schema: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    LocalTax = table.Column<decimal>(nullable: false),
                    LocalFreight = table.Column<decimal>(nullable: false),
                    ForeignTax = table.Column<decimal>(nullable: false),
                    ForeignFreight = table.Column<decimal>(nullable: false),
                    UnitValue = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    BundleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleItem_Bundle_BundleId",
                        column: x => x.BundleId,
                        principalSchema: "Shopping",
                        principalTable: "Bundle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BundleItem_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Common",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Shopping",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Entry = table.Column<DateTime>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    BundleItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItem_BundleItem_BundleItemId",
                        column: x => x.BundleItemId,
                        principalSchema: "Shopping",
                        principalTable: "BundleItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItem_Stock_StockId",
                        column: x => x.StockId,
                        principalSchema: "Inventory",
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementStockItem",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovementDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StockItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementStockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementStockItem_StockItem_StockItemId",
                        column: x => x.StockItemId,
                        principalSchema: "Inventory",
                        principalTable: "StockItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SaleId = table.Column<int>(nullable: false),
                    StockItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItem_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "Sale",
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItem_StockItem_StockItemId",
                        column: x => x.StockItemId,
                        principalSchema: "Inventory",
                        principalTable: "StockItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Administration",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "Administration",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Administration",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Administration",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Administration",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "Administration",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Administration",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_CurrencyId",
                schema: "Common",
                table: "ExchangeRate",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementStockItem_StockItemId",
                schema: "Inventory",
                table: "MovementStockItem",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StateId",
                schema: "Inventory",
                table: "Stock",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StoreId",
                schema: "Inventory",
                table: "Stock",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_BundleItemId",
                schema: "Inventory",
                table: "StockItem",
                column: "BundleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_StockId",
                schema: "Inventory",
                table: "StockItem",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CurrencyId",
                schema: "Sale",
                table: "Sale",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StateId",
                schema: "Sale",
                table: "Sale",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_SaleId",
                schema: "Sale",
                table: "SaleItem",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_StockItemId",
                schema: "Sale",
                table: "SaleItem",
                column: "StockItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleQuota_SaleId",
                schema: "Sale",
                table: "SaleQuota",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_CurrencyId",
                schema: "Shopping",
                table: "Bundle",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_StateId",
                schema: "Shopping",
                table: "Bundle",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleItem_BundleId",
                schema: "Shopping",
                table: "BundleItem",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleItem_CurrencyId",
                schema: "Shopping",
                table: "BundleItem",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BundleItem_ProductId",
                schema: "Shopping",
                table: "BundleItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                schema: "Shopping",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrencyId",
                schema: "Shopping",
                table: "Product",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_FlowId",
                schema: "Workflow",
                table: "State",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_Transition_StateId",
                schema: "Workflow",
                table: "Transition",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "ExchangeRate",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Contact");

            migrationBuilder.DropTable(
                name: "MovementStockItem",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SaleItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "SaleQuota",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "FlowLog",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Transition",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "StockItem",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "BundleItem",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "Stock",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Bundle",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Shopping");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Flow",
                schema: "Workflow");
        }
    }
}
