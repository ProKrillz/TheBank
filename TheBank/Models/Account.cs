namespace TheBank.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
    public decimal Interest { get; set; }
}
public class Checking : Account
{ 
    public Checking()
    {
        Type = AccountType.Checking;
    }   
}
public class Savings : Account
{
    public Savings()
    {
        Type = AccountType.Savings;
    }
}
public class Consumer : Account
{
    public Consumer()
    {
        Type = AccountType.Consumer;
    }
}

