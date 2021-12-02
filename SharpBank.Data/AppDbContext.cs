using Microsoft.EntityFrameworkCore;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Funds> FundsTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bank>().HasMany<Account>(b => b.Accounts).WithOne(a => a.Bank);


            modelBuilder.Entity<Funds>().HasMany<SharpBank.Models.Money>(f => f.Wallets).WithOne(w => w.Funds);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t => t.SourceAccount)
                .WithMany(a => a.DebitTransactions)
                .HasForeignKey(t => t.SourceAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t => t.DestinationAccount)
                .WithMany(a => a.CreditTransactions)
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne<Models.Money>(t => t.Money);

            modelBuilder.Entity<TransactionCharge>()
                .HasOne(tc => tc.Bank)
                .WithMany(b => b.Charges)
                .HasForeignKey(c => c.BankId)
                .OnDelete(DeleteBehavior.Cascade);



            Bank b1 = new Bank
            {
                BankId = Guid.NewGuid(),
                Name = "Test Bank",
                CreatedBy = "Cat",
                CreatedOn = DateTime.Now,
                UpdatedBy = "Cat",
                UpdatedOn = DateTime.Now
            };
            modelBuilder.Entity<Bank>().HasData(
                b1
                );
            Funds f1 = new Funds { Id = Guid.NewGuid() };
            Funds f2 = new Funds { Id = Guid.NewGuid() };
            modelBuilder.Entity<Funds>().HasData(
               f1, f2
               );

            Models.Money m1 = new Models.Money
            {
                Id = Guid.NewGuid(),
                Currency = Money.Currency.INR,
                Amount = 10m,
                FundsId = f1.Id
            };
            Models.Money m2 = new Models.Money
            {
                Id = Guid.NewGuid(),
                Currency = Money.Currency.INR,
                Amount = 10m,
                FundsId = f2.Id
            };
            modelBuilder.Entity<Models.Money>().HasData(m1, m2);
            Account a1 = new Account
            {
                AccountId = Guid.NewGuid(),
                BankId = b1.BankId,
                Name = "Testendra Testy",
                FundsId = f1.Id,
                Password = "password",
                Gender = Models.Enums.Gender.Male,
                Status = Models.Enums.Status.Active
            };
            Account a2 = new Account
            {
                AccountId = Guid.NewGuid(),
                BankId = b1.BankId,
                Name = "Wastendar Wastee",
                FundsId = f1.Id,
                Password = "password",
                Gender = Models.Enums.Gender.Male,
                Status = Models.Enums.Status.Active
            };
            modelBuilder.Entity<Account>().HasData(a1, a2);
            Transaction t1 = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                DestinationAccountId = a2.AccountId,
                SourceAccountId = a1.AccountId,
                MoneyId = m2.Id,
                On = DateTime.Now,
                Type = Models.Enums.TransactionType.RTGS
            };

            modelBuilder.Entity<Transaction>().HasData(
                t1
                );

        }
    }
}
