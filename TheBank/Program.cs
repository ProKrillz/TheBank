namespace TheBank
{
    static class program
    {
        public static void Main()
        {
            Bank theBank = new Bank("Krillz Bank Of Doom");
            do
            {
                Console.WriteLine(theBank.GetBankName());
                Menu();
                switch (InputString("Choise: "))
                {
                    case "a":
                        theBank.CreateAccount(InputString("Name: "));
                        break;
                    case "d":
                        PrintListUsers(theBank.GetAccounts());
                        int accountId = InputInt("Pick id: ");
                        Account foundAccount = theBank.GetAccounts().Find(x => x.Id == accountId);
                        Console.WriteLine(theBank.Deposit(foundAccount, InputDecimal("Deposit amount: "))); 
                        break;
                    case "w":
                        PrintListUsers(theBank.GetAccounts());
                        int accountIdW = InputInt("Pick id: ");
                        Account foundAccountW = theBank.GetAccounts().Find(x => x.Id == accountIdW);
                        Console.WriteLine(theBank.Withdraw(foundAccountW, InputDecimal("Deposit amount: ")));
                        break;
                    case "s":
                        PrintListUsers(theBank.GetAccounts());
                        int accountIdS = InputInt("Pick id: ");
                        Account foundAccountS = theBank.GetAccounts().Find(x => x.Id == accountIdS);
                        Console.WriteLine($"{foundAccountS.Name} Balance: {theBank.Balance(foundAccountS)}");
                        break;
                    case "b":
                        Console.WriteLine($"Bank name: {theBank.GetBankName()}");
                        break;
                    default:
                        break;
                }

            } while (true);
        }

        public static void Menu() 
        {  
            Console.WriteLine("Menu");
            Console.WriteLine("a = Create account");
            Console.WriteLine("d = Deposit");
            Console.WriteLine("w = Witdraw");
            Console.WriteLine("s = Show balance");
            Console.WriteLine("b = Bank");
        }
        public static void PrintListUsers(List<Account> list)
        {
            foreach (Account account in list)
            {
                Console.WriteLine(account.Id);
                Console.WriteLine(account.Name);
                Console.WriteLine();
            }
        }
        static string InputString(string text)
        {
            while (true)
            {
                Console.Write(text);
                string? indput = Console.ReadLine();
                if (indput.Length > 0)
                    return indput;
            }
        }
        static int InputInt(string text)
        {
            int value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    return value = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static decimal InputDecimal(string text)
        {
            decimal value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    return value = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}



