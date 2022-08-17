using TheBank;

Bank theBank = new Bank("Krillz Bank Of Doom");
theBank.CreateAccount("Brian");
List <Account> test = theBank.GetAccounts();
Account Account = test[0];
Console.WriteLine(theBank._bankName);
Console.WriteLine($"Acount created {Account.Name} and balance is {Account.Balance} kr.");
Console.WriteLine($"Deposit: 300 kr. Balance: {theBank.Deposit(Account, 300)} kr.");
Console.WriteLine($"Witdraw: 100 kr. Balance: {theBank.Withdraw(Account, 100)} kr.");
Console.WriteLine($"Balance: {theBank.Balance(Account)} kr.");


