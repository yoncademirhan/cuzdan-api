using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.EntityFramework;

public class ApplicationDbContext : DbContext {
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletTransaction> WalletTransactions { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }
}