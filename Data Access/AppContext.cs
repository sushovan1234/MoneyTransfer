using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Models;

namespace MoneyTransfer.Data_Access
{
    public class AppContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }

        public DbSet<BankDetails> BankDetails { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users", "UserManagement");
            builder.Entity<TransactionDetails>().ToTable("TransactionDetails", "System");
            builder.Entity<BankDetails>().ToTable("BankDetails", "System");
            builder.Entity<BankAccount>().ToTable("BankAccounts", "System");

            builder.Entity<TransactionDetails>(entity =>
            {
                entity.HasKey(u => u.transactionId);
                entity.Property(u => u.transactionId).ValueGeneratedOnAdd();
                entity.HasOne(b => b.User)
                .WithMany(b => b.TransactionDetails)
                .HasForeignKey(b => b.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(u => u.AccountId);
                entity.Property(u => u.AccountId).ValueGeneratedOnAdd();
                entity.HasOne(u => u.Bank)
                .WithMany(u => u.BankAccounts)
                .HasForeignKey(u => u.BankId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<BankDetails>(entity =>
            {
                entity.HasKey(u => u.BankId);
                entity.Property(u => u.BankId).ValueGeneratedOnAdd();
            });
            builder.Entity<BankDetails>().HasData(
            new BankDetails
            {
                BankId = 1,
                BankName = "Standard Chartered Bank Nepal",
                Country = "Nepal",
                IsoCode = "NPR",
                Currency = "Nepalese Rupee",
                SwiftCode = "SCBLNPKA",
                Address = "New Road, Kathmandu, Bagmati, 44600, Nepal"
            },
            new BankDetails
            {
                BankId = 2,
                BankName = "Himalayan Bank Limited",
                Country = "Nepal",
                IsoCode = "NPR",
                Currency = "Nepalese Rupee",
                SwiftCode = "HBLNNPKA",
                Address = "Thamel, Kathmandu, Bagmati, 44600, Nepal"
            },
            new BankDetails
            {
                BankId = 3,
                BankName = "Nepal Investment Bank Limited",
                Country = "Nepal",
                IsoCode = "NPR",
                Currency = "Nepalese Rupee",
                SwiftCode = "NIBLNPKA",
                Address = "Lazimpat, Kathmandu, Bagmati, 44600, Nepal"
            },
            new BankDetails
            {
                BankId = 4,
                BankName = "Nabil Bank Limited",
                Country = "Nepal",
                IsoCode = "NPR",
                Currency = "Nepalese Rupee",
                SwiftCode = "NABLNPKA",
                Address = "Durbar Marg, Kathmandu, Bagmati, 44600, Nepal"
            },

            new BankDetails
            {
                BankId = 5,
                BankName = "Maybank",
                Country = "Malaysia",
                IsoCode = "MYR",
                Currency = "Malaysian Ringgit",
                SwiftCode = "MAYBMYKL",
                Address = "Menara Maybank, 100 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia"
            },
            new BankDetails
            {
                BankId = 6,
                BankName = "CIMB Bank",
                Country = "Malaysia",
                IsoCode = "MYR",
                Currency = "Malaysian Ringgit",
                SwiftCode = "CIBBMYKL",
                Address = "Menara CIMB, 165 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia"
            },
            new BankDetails
            {
                BankId = 7,
                BankName = "Public Bank Berhad",
                Country = "Malaysia",
                IsoCode = "MYR",
                Currency = "Malaysian Ringgit",
                SwiftCode = "PBBEMYKL",
                Address = "Public Bank Building, 146 Jalan Ampang, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia"
            },
            new BankDetails
            {
                BankId = 8,
                BankName = "RHB Bank",
                Country = "Malaysia",
                IsoCode = "MYR",
                Currency = "Malaysian Ringgit",
                SwiftCode = "RHBBMYKL",
                Address = "RHB Tower, 10 Jalan Tun Perak, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia"
            });

            builder.Entity<BankAccount>().HasData(
                new BankAccount
                {
                    AccountId = 1,
                    FirstName = "John",
                    MiddleName = "D.",
                    LastName = "Doe",
                    AccountNumber = "123456789",
                    AccountType = "Savings",
                    Balance = 1000.00m,
                    Country = "Nepal",
                    Address = "123 Main Street, Kathmandu, Bagmati, 44600, Nepal",
                    BankId = 1
                },
                new BankAccount
                {
                    AccountId = 2,
                    FirstName = "Jane",
                    MiddleName = "P.",
                    LastName = "Smith",
                    AccountNumber = "987654321",
                    AccountType = "Checking",
                    Balance = 2000.00m,
                    Country = "Malaysia",
                    Address = "456 Market Street, Kuala Lumpur, Wilayah Persekutuan, 50050, Malaysia",
                    BankId = 5

                },
                new BankAccount
                {
                    AccountId = 3,
                    FirstName = "Alice",
                    MiddleName = "M.",
                    LastName = "Johnson",
                    AccountNumber = "567890123",
                    AccountType = "Business",
                    Country = "Nepal",
                    Balance = 5000.00m,
                    Address = "789 Business Ave, Kathmandu, Bagmati, 44600, Nepal",
                    BankId = 3

                },
                new BankAccount
                {
                    AccountId = 4,
                    FirstName = "Bob",
                    MiddleName = "L.",
                    LastName = "Williams",
                    AccountNumber = "246801357",
                    AccountType = "Savings",
                    Country = "Malaysia",
                    Balance = 3000.00m,
                    Address = "1014 High Street, Kuala Lumpur, Wilayah Persekutuan, 50450, Malaysia",
                    BankId = 6,

                }
            );
        }


    }


}

