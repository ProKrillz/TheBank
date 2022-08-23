namespace TheBank.DAL;

public class AccountListItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
}
