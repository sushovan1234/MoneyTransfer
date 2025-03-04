﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyTransfer.Data_Access;

#nullable disable

namespace MoneyTransfer.Migrations
{
    [DbContext(typeof(MoneyTransfer.Data_Access.AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MoneyTransfer.Models.BankAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("BankAccounts", "System");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountNumber = "123456789",
                            AccountType = "Savings",
                            Address = "123 Main Street, Kathmandu, Bagmati, 44600, Nepal",
                            Balance = 1000.00m,
                            BankId = 1,
                            Country = "Nepal",
                            FirstName = "John",
                            LastName = "Doe",
                            MiddleName = "D."
                        },
                        new
                        {
                            AccountId = 2,
                            AccountNumber = "987654321",
                            AccountType = "Checking",
                            Address = "456 Market Street, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia",
                            Balance = 2000.00m,
                            BankId = 5,
                            Country = "Malaysia",
                            FirstName = "Jane",
                            LastName = "Smith",
                            MiddleName = "P."
                        },
                        new
                        {
                            AccountId = 3,
                            AccountNumber = "567890123",
                            AccountType = "Business",
                            Address = "789 Business Ave, Kathmandu, Bagmati, 44600, Nepal",
                            Balance = 5000.00m,
                            BankId = 3,
                            Country = "Nepal",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            MiddleName = "M."
                        },
                        new
                        {
                            AccountId = 4,
                            AccountNumber = "246801357",
                            AccountType = "Savings",
                            Address = "1014 High Street, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia",
                            Balance = 3000.00m,
                            BankId = 6,
                            Country = "Malaysia",
                            FirstName = "Bob",
                            LastName = "Williams",
                            MiddleName = "L."
                        });
                });

            modelBuilder.Entity("MoneyTransfer.Models.BankDetails", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwiftCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankId");

                    b.ToTable("BankDetails", "System");

                    b.HasData(
                        new
                        {
                            BankId = 1,
                            Address = "New Road, Kathmandu, Bagmati, 44600, Nepal",
                            BankName = "Standard Chartered Bank Nepal",
                            Country = "Nepal",
                            Currency = "Nepalese Rupee",
                            IsoCode = "NPR",
                            SwiftCode = "SCBLNPKA"
                        },
                        new
                        {
                            BankId = 2,
                            Address = "Thamel, Kathmandu, Bagmati, 44600, Nepal",
                            BankName = "Himalayan Bank Limited",
                            Country = "Nepal",
                            Currency = "Nepalese Rupee",
                            IsoCode = "NPR",
                            SwiftCode = "HBLNNPKA"
                        },
                        new
                        {
                            BankId = 3,
                            Address = "Lazimpat, Kathmandu, Bagmati, 44600, Nepal",
                            BankName = "Nepal Investment Bank Limited",
                            Country = "Nepal",
                            Currency = "Nepalese Rupee",
                            IsoCode = "NPR",
                            SwiftCode = "NIBLNPKA"
                        },
                        new
                        {
                            BankId = 4,
                            Address = "Durbar Marg, Kathmandu, Bagmati, 44600, Nepal",
                            BankName = "Nabil Bank Limited",
                            Country = "Nepal",
                            Currency = "Nepalese Rupee",
                            IsoCode = "NPR",
                            SwiftCode = "NABLNPKA"
                        },
                        new
                        {
                            BankId = 5,
                            Address = "Menara Maybank, 100 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia",
                            BankName = "Maybank",
                            Country = "Malaysia",
                            Currency = "Malaysian Ringgit",
                            IsoCode = "MYR",
                            SwiftCode = "MAYBMYKL"
                        },
                        new
                        {
                            BankId = 6,
                            Address = "Menara CIMB, 165 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia",
                            BankName = "CIMB Bank",
                            Country = "Malaysia",
                            Currency = "Malaysian Ringgit",
                            IsoCode = "MYR",
                            SwiftCode = "CIBBMYKL"
                        },
                        new
                        {
                            BankId = 7,
                            Address = "Public Bank Building, 146 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia",
                            BankName = "Public Bank Berhad",
                            Country = "Malaysia",
                            Currency = "Malaysian Ringgit",
                            IsoCode = "MYR",
                            SwiftCode = "PBBEMYKL"
                        },
                        new
                        {
                            BankId = 8,
                            Address = "RHB Tower, 10 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia",
                            BankName = "RHB Bank",
                            Country = "Malaysia",
                            Currency = "Malaysian Ringgit",
                            IsoCode = "MYR",
                            SwiftCode = "RHBBMYKL"
                        });
                });

            modelBuilder.Entity("MoneyTransfer.Models.TransactionDetails", b =>
                {
                    b.Property<int>("transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transactionId"));

                    b.Property<string>("ExchangeRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("PayoutAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceiverBankAccNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverBankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderBankAccNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderBankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("transactionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("transferAmt")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("transactionId");

                    b.HasIndex("Id");

                    b.ToTable("TransactionDetails", "System");
                });

            modelBuilder.Entity("MoneyTransfer.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("formattedAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "UserManagement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MoneyTransfer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MoneyTransfer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyTransfer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MoneyTransfer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyTransfer.Models.BankAccount", b =>
                {
                    b.HasOne("MoneyTransfer.Models.BankDetails", "Bank")
                        .WithMany("BankAccounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("MoneyTransfer.Models.TransactionDetails", b =>
                {
                    b.HasOne("MoneyTransfer.Models.User", "User")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoneyTransfer.Models.BankDetails", b =>
                {
                    b.Navigation("BankAccounts");
                });

            modelBuilder.Entity("MoneyTransfer.Models.User", b =>
                {
                    b.Navigation("TransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
