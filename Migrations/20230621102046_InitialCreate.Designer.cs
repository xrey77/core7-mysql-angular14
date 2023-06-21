﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using core7_msyql_angular14.Helpers;

#nullable disable

namespace core7_mysql_angular14.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230621102046_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("core7_msyql_angular14.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Alert_level")
                        .HasColumnType("int")
                        .HasColumnName("alert_level");

                    b.Property<string>("Category")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("category");

                    b.Property<decimal?>("Cost_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("cost_price");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<int?>("Critical_level")
                        .HasColumnType("int")
                        .HasColumnName("critical_level");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descriptions");

                    b.Property<string>("Prod_pic")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("prod_pic");

                    b.Property<int?>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<decimal?>("Sale_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("sale_price");

                    b.Property<decimal?>("Sell_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("sell_price");

                    b.Property<string>("Unit")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("unit");

                    b.Property<DateTime>("Updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("core7_msyql_angular14.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("firstname");

                    b.Property<int?>("Isactivated")
                        .HasColumnType("int")
                        .HasColumnName("isactivated");

                    b.Property<int?>("Isblocked")
                        .HasColumnType("int")
                        .HasColumnName("isblocked");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("lastname");

                    b.Property<int?>("Mailtoken")
                        .HasColumnType("int")
                        .HasColumnName("mailtoken");

                    b.Property<string>("Mobile")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("mobile");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("Profilepic")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("profilepic");

                    b.Property<string>("Qrcodeurl")
                        .HasColumnType("varchar(300)")
                        .HasColumnName("qrcodeurl");

                    b.Property<string>("Roles")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("roles");

                    b.Property<string>("Secretkey")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("sale_price");

                    b.Property<DateTime>("Updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
