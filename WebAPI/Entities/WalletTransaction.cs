namespace WebAPI.Entities;

public class WalletTransaction : BaseEntity {
    public int WalletId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string? Description { get; set; }
    public Wallet Wallet { get; set; }

}