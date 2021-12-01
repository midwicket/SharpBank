using Microsoft.EntityFrameworkCore;
using SharpBank.Models;

namespace SharpBank.API
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
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


            modelBuilder.Entity<Funds>().HasMany<SharpBank.Models.Money>(f => f.Wallets).WithOne(w=>w.Funds);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t=>t.SourceAccount)
                .WithMany(a=>a.DebitTransactions)
                .HasForeignKey(t=>t.SourceAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t => t.DestinationAccount)
                .WithMany(a => a.CreditTransactions)
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);

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
            modelBuilder.Entity<Funds>().HasData(
               f1
               );
            modelBuilder.Entity<Account>().HasData(
                new Account { 
                AccountId = Guid.NewGuid(),
                BankId=b1.BankId,
                Name="Testendra Testy",
                FundsId = f1.Id,
                Password = "password",
                Gender = Models.Enums.Gender.Male,
                Status = Models.Enums.Status.Active
                }
                );
        }
    }
}
