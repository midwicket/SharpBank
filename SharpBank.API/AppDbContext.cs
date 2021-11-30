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

        }
    }
}
