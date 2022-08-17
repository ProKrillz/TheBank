namespace TheBank
{
    public class Bank
    {
        readonly string _bankName;
        int _idCounter;
        List<Account> _accounts;

        public Bank(string name)
        {
            _bankName = name;
            _accounts = new List<Account>();
        }
        public void CreateAccount(string name)
        {
            _accounts.Add(new Account { Id = ++_idCounter, Name = name, Balance = 0 });
        }
        public string GetBankName() { return _bankName; }
        public List<Account> GetAccounts() { return _accounts; }
        public decimal Deposit(Account account, decimal money)
        {
            account.Balance += money;
            return account.Balance;
        }
        public decimal Withdraw(Account account, decimal money)
        {
            account.Balance -= money;
            return account.Balance;
        }
        public decimal Balance(Account account) { return account.Balance; }

    }
}
