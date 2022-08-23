using System.Net.Http.Headers;
using TheBank.DAL;
using TheBank.Exceptions;
using TheBank.Models;

namespace TheBank.Repository;

internal class Repo : IBank
{
    private int _idCounter;
    private List<Account> _accounts = new();


    public void CreateAccount(string name, AccountType type)
    {
        switch (type)
        {
            case AccountType.Checking:
                _accounts.Add(new Checking { Id = ++_idCounter, Name = name });
                break;
            case AccountType.Savings:
                _accounts.Add(new Savings { Id = ++_idCounter, Name = name });
                break;
            case AccountType.Consumer:
                _accounts.Add(new Consumer { Id = ++_idCounter, Name = name });
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Returns all accounts in a list
    /// </summary>
    /// <returns>List</returns>
    public List<Account> GetAccounts() { return _accounts; }
    /// <summary>
    /// Add money to account balance
    /// </summary>
    /// <param name="account"></param>
    /// <param name="money"></param>
    /// <returns>decimal</returns>
    public void Deposit(Account account, decimal money) { account.Balance += money; }
    /// <summary>
    /// minus money from account balance
    /// </summary>
    /// <param name="account"></param>
    /// <param name="money"></param>
    /// <returns>decimal</returns>
    public void Withdraw(Account account, decimal money)
    {
        try
        {
            if (account.Balance < money)
                throw new OverdraftException("Balance will go in minus, not allow");
            account.Balance -= money;
        }
        catch (OverdraftException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// Returns account balance
    /// </summary>
    /// <param name="account"></param>
    /// <returns>decimal</returns>
    public decimal Balance(Account account) { return account.Balance; }
    /// <summary>
    /// pluses every diffrent account balance
    /// </summary>
    /// <returns>all accounts balance</returns>
    public decimal BankHolding()
    {
        decimal bankhold = 0;
        foreach (Account item in _accounts)
            bankhold += item.Balance;

        return bankhold;
    }
    public void ChargeInterest()
    {
        foreach (Account item in _accounts)
        {
            if (item.Type == AccountType.Checking)
            {
                item.Interest = 1.005M;
                item.Balance *= item.Interest;
            }
            if (item.Type == AccountType.Savings)
            {
                if (item.Balance > 50000)
                {
                    if (item.Balance >= 100000)
                    {
                        item.Interest = 1.03M;
                        item.Balance *= item.Interest;
                    }
                    else
                    {
                        item.Interest = 1.02M;
                        item.Balance *= item.Interest;
                    }
                }
                else
                {
                    item.Interest = 1.01M;
                    item.Balance *= item.Interest;
                }
            }
            if (item.Type == AccountType.Consumer)
            {
                if (item.Balance >= 0)
                {
                    item.Interest = 1.001M;
                    item.Balance *= item.Interest;
                }
                else
                {
                    item.Interest = 1.20M;
                    item.Balance *= item.Interest;
                }
            }
        }
    }

    public List<AccountListItem> GetAllAcc()
    {
        List<AccountListItem> acc = new List<AccountListItem>();
        foreach (Account item in _accounts)
            acc.Add(new AccountListItem { Id = item.Id, Name = item.Name, Balance = item.Balance, Type = item.Type });

        return acc;
    }
}


