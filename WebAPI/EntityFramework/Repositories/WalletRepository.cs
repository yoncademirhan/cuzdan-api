using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;

namespace WebAPI.EntityFramework.Repositories;

public class WalletRepository : IWalletRepository {
    private readonly ApplicationDbContext _context;

    public WalletRepository(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<Wallet> CreateWallet(Wallet wallet) {
        await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<Boolean> DeleteWallet(Wallet wallet) {
        _context.Wallets.Remove(wallet);
        return await _context.SaveChangesAsync() > 0;
    }


    public async Task<Wallet> GetWalletById(Int32 id) {
        return await _context.Wallets
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync(wallet => wallet.Id == id);
    }

    public async Task<List<Wallet>> GetWallets(Int32 userId) {
        return await _context.Wallets.Where(wallet => wallet.UserId == userId).ToListAsync();
    }

    public async Task<Wallet> UpdateWallet(Wallet wallet) {
        _context.Wallets.Update(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }
}