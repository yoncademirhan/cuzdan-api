using WebAPI.Entities;

namespace WebAPI.Interfaces.Repositories;

public interface IWalletRepository {
    Task<Wallet> CreateWallet(Wallet wallet);
    Task<Wallet> UpdateWallet(Wallet wallet);
    Task<bool> DeleteWallet(Wallet wallet);
    Task<Wallet> GetWalletById(int id); // transactions
    Task<List<Wallet>> GetWallets(int userId);
}