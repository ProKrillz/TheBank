using TheBank.BLL;
using TheBank.Models;
using TheBank.DAL;
using Microsoft.Extensions.DependencyInjection;
using TheBank.Repository;

namespace TheBank;

static class program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection().AddSingleton<IBank, Repo>().AddSingleton<IInput, RepoInput>().BuildServiceProvider();

        Bank theBank = new Bank("Krillz Bank Of Doom", serviceProvider.GetService<IBank>(), serviceProvider.GetService<IInput>());
        bool runTime = true;
        do
        {
            Console.Clear();
            Console.WriteLine(theBank.GetBankName());
            theBank.Menu();
            
            switch (theBank.ifi.InputString("Choise: "))
            {
                case "a":
                    theBank.ifb.CreateAccount(theBank.ifi.InputString("Name: "), theBank.ifi.CreateAccountMenu());
                    break;
                case "d":
                    theBank.ifi.PrintListUsers(theBank.ifb.GetAllAcc());
                    Account foundAccount = theBank.ifb.GetAccounts().Find(x => x.Id == theBank.ifi.InputInt("Pick id: "));
                    theBank.ifb.Deposit(foundAccount, theBank.ifi.InputDecimal("Deposit amount: "));
                    Console.ReadKey();
                    break;
                case "w":
                    theBank.ifi.PrintListUsers(theBank.ifb.GetAllAcc());
                    Account foundAccountW = theBank.ifb.GetAccounts().Find(x => x.Id == theBank.ifi.InputInt("Pick id: "));
                    theBank.ifb.Withdraw(foundAccountW, theBank.ifi.InputDecimal("Deposit amount: "));
                    Console.ReadKey();
                    break;
                case "sa":
                    theBank.ifi.PrintListUsers(theBank.ifb.GetAllAcc());
                    Console.ReadKey();
                    break;
                case "s":
                    theBank.ifi.PrintListUsers(theBank.ifb.GetAllAcc());
                    Account foundAccountS = theBank.ifb.GetAccounts().Find(x => x.Id == theBank.ifi.InputInt("Pick id: "));
                    Console.WriteLine($"{foundAccountS.Name} Balance: {theBank.ifb.Balance(foundAccountS)}");
                    Console.ReadKey();
                    break;
                case "h":
                    Console.WriteLine($"Bank holding: {theBank.ifb.BankHolding()}");
                    Console.ReadKey();
                    break;
                case "b":
                    Console.WriteLine($"Bank name: {theBank.GetBankName()}");
                    Console.ReadKey();
                    break;
                case "c":
                    theBank.ifb.ChargeInterest();
                    break;
                case "x":
                    runTime = false;
                    break;
                default:
                    break;
            }
        } while (runTime);
    }
}



