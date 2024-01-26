namespace WebAPI.Entities;

public class Wallet : BaseEntity {
    public int UserId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
    public string? Description { get; set; }
    public User user { get; set; }


    public ICollection<WalletTransaction> Transactions { get; set; }
}
