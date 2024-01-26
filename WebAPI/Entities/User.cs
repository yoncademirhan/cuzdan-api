namespace WebAPI.Entities;

public class User:BaseEntity {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }


    public ICollection<Wallet>Wallets { get; set; }
}