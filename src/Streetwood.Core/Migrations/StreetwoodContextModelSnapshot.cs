﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Domain.Implementation;

namespace Streetwood.Core.Migrations
{
    [DbContext(typeof(StreetwoodContext))]
    partial class StreetwoodContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Country");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("PostCode")
                        .HasMaxLength(8);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Charm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharmCategoryId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<string>("NameEng");

                    b.Property<decimal>("Price");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CharmCategoryId");

                    b.ToTable("Charms");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.CharmCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("NameEng");

                    b.Property<int>("Status");

                    b.Property<string>("UniqueName");

                    b.HasKey("Id");

                    b.ToTable("CharmCategories");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.DiscountCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductCategoryDiscountId");

                    b.Property<Guid?>("ProductCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryDiscountId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("DiscountCategories");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsMain");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AddressId");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("ClosedDateTime");

                    b.Property<string>("Comment");

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<int?>("DiscountValue");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsClosed");

                    b.Property<Guid?>("OrderDiscountId");

                    b.Property<decimal>("ShipmentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrderDiscountId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.OrderDiscount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableFrom");

                    b.Property<DateTime>("AvailableTo");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionEng");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<string>("NameEng")
                        .HasMaxLength(30);

                    b.Property<int>("PercentValue");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.ToTable("OrderDiscounts");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.OrderPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderPaymentId");

                    b.Property<Guid?>("PaymentId");

                    b.Property<int>("Status");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("OrderPaymentId")
                        .IsUnique()
                        .HasFilter("[OrderPaymentId] IS NOT NULL");

                    b.HasIndex("PaymentId");

                    b.ToTable("OrderPayment");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.OrderShipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderShipmentId");

                    b.Property<Guid?>("ShipmentId");

                    b.Property<int>("Status");

                    b.Property<string>("TrackingId");

                    b.Property<string>("TrackingUrl");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("OrderShipmentId")
                        .IsUnique()
                        .HasFilter("[OrderShipmentId] IS NOT NULL");

                    b.HasIndex("ShipmentId");

                    b.ToTable("OrderShipment");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("NameEng");

                    b.Property<int>("PaymentType");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasDiscriminator<int>("PaymentType");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptCharms");

                    b.Property<bool>("AcceptGraver");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionEng");

                    b.Property<string>("ImagesPath");

                    b.Property<int>("MaxCharmsCount");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("NameEng")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductCategoryId");

                    b.Property<string>("Sizes")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasOneProduct");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<string>("NameEng");

                    b.Property<Guid?>("ParentId");

                    b.Property<int>("Status");

                    b.Property<string>("UniqueName");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductCategoryDiscount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableFrom");

                    b.Property<DateTime>("AvailableTo");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionEng");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<string>("NameEng")
                        .HasMaxLength(30);

                    b.Property<int>("PercentValue");

                    b.HasKey("Id");

                    b.ToTable("ProductCategoryDiscounts");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductColor", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<string>("Name");

                    b.Property<string>("HexValue");

                    b.HasKey("ProductId", "Name");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<decimal>("CharmsPrice");

                    b.Property<string>("Color");

                    b.Property<string>("Comment");

                    b.Property<decimal>("CurrentProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DiscountValue");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Graver");

                    b.Property<int?>("OrderId");

                    b.Property<Guid?>("ProductCategoryDiscountId");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductCategoryDiscountId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductOrderCharm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharmId");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductOrderId");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("CharmId");

                    b.HasIndex("ProductOrderId");

                    b.ToTable("ProductOrderCharms");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionEng");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("NameEng")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChangePasswordToken");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasMaxLength(40);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("Salt");

                    b.Property<int>("Type");

                    b.Property<int>("UserStatus");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.BankTransferPayment", b =>
                {
                    b.HasBaseType("Streetwood.Core.Domain.Entities.Payment");

                    b.Property<int>("AccountNumber");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Charm", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.CharmCategory", "CharmCategory")
                        .WithMany("Charms")
                        .HasForeignKey("CharmCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.DiscountCategory", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.ProductCategoryDiscount", "ProductCategoryDiscount")
                        .WithMany("DiscountCategories")
                        .HasForeignKey("ProductCategoryDiscountId");

                    b.HasOne("Streetwood.Core.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("DiscountCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Image", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Streetwood.Core.Domain.Entities.OrderDiscount", "OrderDiscount")
                        .WithMany("Orders")
                        .HasForeignKey("OrderDiscountId");

                    b.HasOne("Streetwood.Core.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.OrderPayment", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Order")
                        .WithOne("OrderPayment")
                        .HasForeignKey("Streetwood.Core.Domain.Entities.OrderPayment", "OrderPaymentId");

                    b.HasOne("Streetwood.Core.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.OrderShipment", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Order")
                        .WithOne("OrderShipment")
                        .HasForeignKey("Streetwood.Core.Domain.Entities.OrderShipment", "OrderShipmentId");

                    b.HasOne("Streetwood.Core.Domain.Entities.Shipment", "Shipment")
                        .WithMany()
                        .HasForeignKey("ShipmentId");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.ProductCategory", "Parent")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductColor", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductOrder", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Streetwood.Core.Domain.Entities.ProductCategoryDiscount", "ProductCategoryDiscount")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductCategoryDiscountId");

                    b.HasOne("Streetwood.Core.Domain.Entities.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Streetwood.Core.Domain.Entities.ProductOrderCharm", b =>
                {
                    b.HasOne("Streetwood.Core.Domain.Entities.Charm", "Charm")
                        .WithMany("ProductOrderCharms")
                        .HasForeignKey("CharmId");

                    b.HasOne("Streetwood.Core.Domain.Entities.ProductOrder", "ProductOrder")
                        .WithMany("ProductOrderCharms")
                        .HasForeignKey("ProductOrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
