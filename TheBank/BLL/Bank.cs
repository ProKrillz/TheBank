using TheBank.Repository;

namespace TheBank.BLL;
public class Bank
{
    public readonly IBank ifb;
    public readonly IInput ifi;
    readonly string _bankName;

    public Bank(string name, IBank ib, IInput fi)
    {
        _bankName = name;
        ifb = ib;
        ifi = fi;
    }
    /// <summary>
    /// Returns bank name
    /// </summary>
    /// <returns>string with bank name</returns>
    public string GetBankName() { return _bankName; }
    /// <summary>
    /// Show menu
    /// </summary>
    public void Menu()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("a = Create account");
        Console.WriteLine("d = Deposit");
        Console.WriteLine("w = Witdraw");
        Console.WriteLine("sa = Show all users");
        Console.WriteLine("s = Show balance on user");
        Console.WriteLine("h = BankHolding");
        Console.WriteLine("b = Bank");
        Console.WriteLine("c = ChargeInterest");
        Console.WriteLine("x = Exit");
    }
}
