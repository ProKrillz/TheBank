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
        /// <summary>
        /// Creates a user with name and count id with 1 and add to accountlist
        /// </summary>
        /// <param name="name"></param>
        public void CreateAccount(string name, AccountType type)
        {
            switch (type)
            {
                case AccountType.Checking:
                    _accounts.Add(new Checking { Id = ++_idCounter, Name = name, Type = type });
                    break;
                case AccountType.Savings:
                    _accounts.Add(new Savings { Id = ++_idCounter, Name = name, Type = type });
                    break;
                case AccountType.Consumer:
                    _accounts.Add(new Consumer { Id = ++_idCounter, Name = name, Type = type });
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Returns bank name
        /// </summary>
        /// <returns>string</returns>
        public string GetBankName() { return _bankName; }
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
        public decimal Deposit(Account account, decimal money)
        {
            account.Balance += money;
            return account.Balance;
        }
        /// <summary>
        /// minus money from account balance
        /// </summary>
        /// <param name="account"></param>
        /// <param name="money"></param>
        /// <returns>decimal</returns>
        public decimal Withdraw(Account account, decimal money)
        {
            account.Balance -= money;
            return account.Balance;
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
        /// <returns>decimal</returns>
        public decimal BankHolding()
        {
            decimal bankhold = 0;
            foreach (Account item in _accounts)
            {
                bankhold += item.Balance;
            }
            return bankhold;
        }
        public void ChargeInterest()
        {
            foreach (Account item in _accounts)
            {
                item.ChargeInterest();
            }
        }
    }
}
