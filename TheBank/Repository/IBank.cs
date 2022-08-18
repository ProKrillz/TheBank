using TheBank.DAL;
using TheBank.Models;

namespace TheBank.Repository
{
    internal interface IBank
    {
        public void CreateAccount(string name, AccountType type);
        public string GetBankName();
        public List<Account> GetAccounts();
        public decimal Deposit(Account account, decimal money);
        public decimal Withdraw(Account account, decimal money);
        public decimal Balance(Account account);
        public decimal BankHolding();
        public void ChargeInterest();
        public List<AccountListItem> GetAllAcc();
    }
}
