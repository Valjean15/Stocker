﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(StockerContext))]
    partial class StockerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Administration.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User","Administration");
                });

            modelBuilder.Entity("Models.Common.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brand","Common");
                });

            modelBuilder.Entity("Models.Common.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("Principal");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.ToTable("Currency","Common");
                });

            modelBuilder.Entity("Models.Common.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangeRateDate");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("PurchaseRate");

                    b.Property<decimal>("SaleRate");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ExchangeRate","Common");
                });

            modelBuilder.Entity("Models.Common.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("Name");

                    b.Property<decimal>("SaleUnitPrice");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("StateId");

                    b.ToTable("Product","Common");
                });

            modelBuilder.Entity("Models.Common.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Store","Common");
                });

            modelBuilder.Entity("Models.Contact.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("ContactType");

                    b.Property<int>("Gender");

                    b.Property<string>("Identification");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Contact","Contact");
                });

            modelBuilder.Entity("Models.Inventory.BundleMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BundleItemId");

                    b.Property<DateTime>("MovementDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("StockItemId");

                    b.HasKey("Id");

                    b.HasIndex("BundleItemId");

                    b.HasIndex("StockItemId");

                    b.ToTable("BundleMovement","Inventory");
                });

            modelBuilder.Entity("Models.Inventory.SaleMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MovementDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("SaleItemId");

                    b.Property<int>("StockItemId");

                    b.HasKey("Id");

                    b.HasIndex("SaleItemId");

                    b.HasIndex("StockItemId");

                    b.ToTable("SaleMovement","Inventory");
                });

            modelBuilder.Entity("Models.Inventory.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("StateId");

                    b.Property<int>("StockType");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("StoreId");

                    b.ToTable("Stock","Inventory");
                });

            modelBuilder.Entity("Models.Inventory.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Entry");

                    b.Property<int>("ProductId");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockId");

                    b.ToTable("StockItem","Inventory");
                });

            modelBuilder.Entity("Models.Inventory.TransferMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MovementDate");

                    b.Property<int>("Quantity");

                    b.Property<int>("StockItemId");

                    b.Property<int>("TargetStockItemId");

                    b.HasKey("Id");

                    b.HasIndex("StockItemId");

                    b.HasIndex("TargetStockItemId");

                    b.ToTable("TransferMovement","Inventory");
                });

            modelBuilder.Entity("Models.Sale.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("SaleDate");

                    b.Property<int>("StateId");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .IsUnique();

                    b.HasIndex("CurrencyId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("Sale","Sale");
                });

            modelBuilder.Entity("Models.Sale.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SaleId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItem","Sale");
                });

            modelBuilder.Entity("Models.Sale.SaleQuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Paid");

                    b.Property<DateTime?>("PaidDate");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int>("SaleId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleQuota","Sale");
                });

            modelBuilder.Entity("Models.Shopping.Bundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Arrival");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("Discount");

                    b.Property<decimal>("ForeignFreight");

                    b.Property<decimal>("ForeignTax");

                    b.Property<decimal>("LocalFreight");

                    b.Property<decimal>("LocalTax");

                    b.Property<DateTime>("Order");

                    b.Property<string>("Reference");

                    b.Property<int>("StateId");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("Bundle","Shopping");
                });

            modelBuilder.Entity("Models.Shopping.BundleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BundleId");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("Discount");

                    b.Property<decimal>("ForeignFreight");

                    b.Property<decimal>("ForeignTax");

                    b.Property<decimal>("LocalFreight");

                    b.Property<decimal>("LocalTax");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitValue");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.HasIndex("CurrencyId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("BundleItem","Shopping");
                });

            modelBuilder.Entity("Models.Workflow.Flow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Flow","Workflow");
                });

            modelBuilder.Entity("Models.Workflow.FlowLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndStateId");

                    b.Property<int>("EntityId");

                    b.Property<int>("FlowId");

                    b.Property<DateTime>("Log");

                    b.Property<int>("StartStateId");

                    b.Property<string>("TableName");

                    b.Property<int>("TransitionId");

                    b.HasKey("Id");

                    b.ToTable("FlowLog","Workflow");
                });

            modelBuilder.Entity("Models.Workflow.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlowId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FlowId");

                    b.ToTable("State","Workflow");
                });

            modelBuilder.Entity("Models.Workflow.Transition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EndStateId");

                    b.Property<string>("Name");

                    b.Property<int?>("StartStateId");

                    b.HasKey("Id");

                    b.ToTable("Transition","Workflow");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.Administration.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.Administration.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Administration.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.Administration.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Common.ExchangeRate", b =>
                {
                    b.HasOne("Models.Common.Currency", "Currency")
                        .WithMany("ExchangesRates")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Common.Product", b =>
                {
                    b.HasOne("Models.Common.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Workflow.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Inventory.BundleMovement", b =>
                {
                    b.HasOne("Models.Shopping.BundleItem", "BundleItem")
                        .WithMany()
                        .HasForeignKey("BundleItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Inventory.StockItem", "StockItem")
                        .WithMany("BundleMovements")
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Inventory.SaleMovement", b =>
                {
                    b.HasOne("Models.Sale.SaleItem", "SaleItem")
                        .WithMany()
                        .HasForeignKey("SaleItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Inventory.StockItem", "StockItem")
                        .WithMany("SaleMovements")
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Inventory.Stock", b =>
                {
                    b.HasOne("Models.Workflow.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Common.Store", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Inventory.StockItem", b =>
                {
                    b.HasOne("Models.Common.Product", "Product")
                        .WithMany("StockItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Inventory.Stock", "Stock")
                        .WithMany("Items")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Inventory.TransferMovement", b =>
                {
                    b.HasOne("Models.Inventory.StockItem", "StockItem")
                        .WithMany("TransferMovements")
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Inventory.StockItem", "TargetStockItem")
                        .WithMany()
                        .HasForeignKey("TargetStockItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Sale.Sale", b =>
                {
                    b.HasOne("Models.Contact.Contact", "Contact")
                        .WithOne()
                        .HasForeignKey("Models.Sale.Sale", "ContactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Workflow.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Administration.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Sale.SaleItem", b =>
                {
                    b.HasOne("Models.Common.Product", "Product")
                        .WithMany("SaleItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Sale.Sale", "Sale")
                        .WithMany("Items")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Sale.SaleQuota", b =>
                {
                    b.HasOne("Models.Sale.Sale", "Sale")
                        .WithMany("Quotas")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Shopping.Bundle", b =>
                {
                    b.HasOne("Models.Common.Currency", "Currency")
                        .WithOne()
                        .HasForeignKey("Models.Shopping.Bundle", "CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Workflow.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Administration.User", "User")
                        .WithMany("Bundles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Shopping.BundleItem", b =>
                {
                    b.HasOne("Models.Shopping.Bundle", "Bundle")
                        .WithMany("Items")
                        .HasForeignKey("BundleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Common.Currency", "Currency")
                        .WithOne()
                        .HasForeignKey("Models.Shopping.BundleItem", "CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Common.Product", "Product")
                        .WithMany("BundleItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Workflow.State", b =>
                {
                    b.HasOne("Models.Workflow.Flow", "Flow")
                        .WithMany("States")
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
