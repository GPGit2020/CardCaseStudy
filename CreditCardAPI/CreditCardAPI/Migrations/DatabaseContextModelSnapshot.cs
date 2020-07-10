﻿// <auto-generated />
using System;
using CreditCardAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CreditCardEligibilityToolAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CreditCardEligibilityToolAPI.Model.CardEligibilityDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("APROnCard");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("UserCardStatus")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId");

                    b.Property<string>("UserPromotionalMsg")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("CardEligibilityDetail");
                });

            modelBuilder.Entity("CreditCardEligibilityToolAPI.Model.UserDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AnnualSalary")
                        .HasColumnType("decimal");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("DateTime");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("CreditCardEligibilityToolAPI.Model.CardEligibilityDetail", b =>
                {
                    b.HasOne("CreditCardEligibilityToolAPI.Model.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
