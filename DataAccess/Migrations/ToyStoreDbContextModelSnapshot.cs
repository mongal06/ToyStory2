﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ToyStoreDbContext))]
    partial class ToyStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId")
                        .HasName("PK__Categori__19093A2B0B947ECC");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B89C5ED1AB");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Models.CustomerOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("OrderId")
                        .HasName("PK__Customer__C3905BAFBF675489");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("Domain.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DiscountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("DiscountId")
                        .HasName("PK__Discount__E43F6DF694092D03");

                    b.HasIndex("ProductId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04FF1453BEA25");

                    b.HasIndex("StoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30CDC4E6D30");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    b.HasKey("ProductId")
                        .HasName("PK__Products__B40CC6EDE791018D");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Models.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PromotionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("PromotionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("PromotionId")
                        .HasName("PK__Promotio__52C42F2FAA4627B5");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Domain.Models.PromotionProduct", b =>
                {
                    b.Property<int>("PromotionProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PromotionProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionProductId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("PromotionId")
                        .HasColumnType("int")
                        .HasColumnName("PromotionID");

                    b.HasKey("PromotionProductId")
                        .HasName("PK__Promotio__C7B85D3C4EB7EEBB");

                    b.HasIndex("ProductId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionProducts");
                });

            modelBuilder.Entity("Domain.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PurchaseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<DateOnly>("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PurchaseId")
                        .HasName("PK__Purchase__6B0A6BDE3DCBD1B7");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Domain.Models.PurchaseDetail", b =>
                {
                    b.Property<int>("PurchaseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PurchaseDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseDetailId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int")
                        .HasColumnName("PurchaseID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PurchaseDetailId")
                        .HasName("PK__Purchase__88C328D5FBF638A0");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("Domain.Models.Return", b =>
                {
                    b.Property<int>("ReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReturnID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnId"));

                    b.Property<DateOnly>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int")
                        .HasColumnName("SaleID");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ReturnId")
                        .HasName("PK__Returns__F445E9886B172445");

                    b.HasIndex("SaleId");

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("Domain.Models.ReturnDetail", b =>
                {
                    b.Property<int>("ReturnDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReturnDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnDetailId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ReturnId")
                        .HasColumnType("int")
                        .HasColumnName("ReturnID");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ReturnDetailId")
                        .HasName("PK__ReturnDe__8B89C9EA2C5D9778");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReturnId");

                    b.ToTable("ReturnDetails");
                });

            modelBuilder.Entity("Domain.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateOnly>("SaleDate")
                        .HasColumnType("date");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("SaleId")
                        .HasName("PK__Sales__1EE3C41F2099BE4B");

                    b.HasIndex("StoreId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Domain.Models.SaleDetail", b =>
                {
                    b.Property<int>("SaleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaleDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleDetailId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int")
                        .HasColumnName("SaleID");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("SaleDetailId")
                        .HasName("PK__SaleDeta__70DB141E222D34A8");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleDetails");
                });

            modelBuilder.Entity("Domain.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StoreId")
                        .HasName("PK__Stores__3B82F0E19975595C");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Domain.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("ContactName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierId")
                        .HasName("PK__Supplier__4BE66694A2D7B0E7");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Domain.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransactionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactionId")
                        .HasName("PK__Transact__55433A4B78F76695");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WarehouseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WarehouseId")
                        .HasName("PK__Warehous__2608AFD93D451939");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Domain.Models.WarehouseStock", b =>
                {
                    b.Property<int>("WarehouseStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WarehouseStockID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseStockId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int")
                        .HasColumnName("WarehouseID");

                    b.HasKey("WarehouseStockId")
                        .HasName("PK__Warehous__8B0900A3AA943CC1");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseStock", (string)null);
                });

            modelBuilder.Entity("Domain.Models.CustomerOrder", b =>
                {
                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__CustomerO__Custo__403A8C7D");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Models.Discount", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("Discounts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Discounts__Produ__4D94879B");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__Employees__Store__3B75D760");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("Domain.Models.CustomerOrder", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__4316F928");

                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderDeta__Produ__440B1D61");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Products__Catego__2A4B4B5E");

                    b.HasOne("Domain.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK__Products__Suppli__2B3F6F97");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Models.PromotionProduct", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("PromotionProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Promotion__Produ__534D60F1");

                    b.HasOne("Domain.Models.Promotion", "Promotion")
                        .WithMany("PromotionProducts")
                        .HasForeignKey("PromotionId")
                        .HasConstraintName("FK__Promotion__Promo__52593CB8");

                    b.Navigation("Product");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Domain.Models.Purchase", b =>
                {
                    b.HasOne("Domain.Models.Supplier", "Supplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK__Purchases__Suppl__2E1BDC42");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Models.PurchaseDetail", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__PurchaseD__Produ__31EC6D26");

                    b.HasOne("Domain.Models.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .HasConstraintName("FK__PurchaseD__Purch__30F848ED");

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Domain.Models.Return", b =>
                {
                    b.HasOne("Domain.Models.Sale", "Sale")
                        .WithMany("Returns")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("FK__Returns__SaleID__46E78A0C");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Domain.Models.ReturnDetail", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("ReturnDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ReturnDet__Produ__4AB81AF0");

                    b.HasOne("Domain.Models.Return", "Return")
                        .WithMany("ReturnDetails")
                        .HasForeignKey("ReturnId")
                        .HasConstraintName("FK__ReturnDet__Retur__49C3F6B7");

                    b.Navigation("Product");

                    b.Navigation("Return");
                });

            modelBuilder.Entity("Domain.Models.Sale", b =>
                {
                    b.HasOne("Domain.Models.Store", "Store")
                        .WithMany("Sales")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__Sales__StoreID__34C8D9D1");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Models.SaleDetail", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("SaleDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__SaleDetai__Produ__38996AB5");

                    b.HasOne("Domain.Models.Sale", "Sale")
                        .WithMany("SaleDetails")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("FK__SaleDetai__SaleI__37A5467C");

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Domain.Models.WarehouseStock", b =>
                {
                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany("WarehouseStocks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Warehouse__Produ__59063A47");

                    b.HasOne("Domain.Models.Warehouse", "Warehouse")
                        .WithMany("WarehouseStocks")
                        .HasForeignKey("WarehouseId")
                        .HasConstraintName("FK__Warehouse__Wareh__5812160E");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Navigation("CustomerOrders");
                });

            modelBuilder.Entity("Domain.Models.CustomerOrder", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("OrderDetails");

                    b.Navigation("PromotionProducts");

                    b.Navigation("PurchaseDetails");

                    b.Navigation("ReturnDetails");

                    b.Navigation("SaleDetails");

                    b.Navigation("WarehouseStocks");
                });

            modelBuilder.Entity("Domain.Models.Promotion", b =>
                {
                    b.Navigation("PromotionProducts");
                });

            modelBuilder.Entity("Domain.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("Domain.Models.Return", b =>
                {
                    b.Navigation("ReturnDetails");
                });

            modelBuilder.Entity("Domain.Models.Sale", b =>
                {
                    b.Navigation("Returns");

                    b.Navigation("SaleDetails");
                });

            modelBuilder.Entity("Domain.Models.Store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Domain.Models.Supplier", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Domain.Models.Warehouse", b =>
                {
                    b.Navigation("WarehouseStocks");
                });
#pragma warning restore 612, 618
        }
    }
}