using TheBank.DAL;
using TheBank.Models;

namespace TheBank.Repository;

public interface IBank
{
    public void CreateAccount(string name, AccountType type);
    public List<Account> GetAccounts();
    public void Deposit(Account account, decimal money);
    public void Withdraw(Account account, decimal money);
    public decimal Balance(Account account);
    public decimal BankHolding();
    public void ChargeInterest();
    public List<AccountListItem> GetAllAcc();
}
