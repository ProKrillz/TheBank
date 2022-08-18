namespace TheBank
{
    static class program
    {
        public static void Main()
        {
            Bank theBank = new Bank("Krillz Bank Of Doom");
            bool runTime = true;
            do
            {
                Console.Clear();
                Console.WriteLine(theBank.GetBankName());
                Menu();
                switch (InputString("Choise: "))
                {
                    case "a":
                        theBank.CreateAccount(InputString("Name: "), CreateAccountMenu());
                        break;
                    case "d":
                        PrintListUsers(theBank.GetAccounts());
                        int accountId = InputInt("Pick id: ");
                        Account foundAccount = theBank.GetAccounts().Find(x => x.Id == accountId);
                        Console.WriteLine(theBank.Deposit(foundAccount, InputDecimal("Deposit amount: ")));
                        Console.ReadKey();
                        break;
                    case "w":
                        PrintListUsers(theBank.GetAccounts());
                        int accountIdW = InputInt("Pick id: ");
                        Account foundAccountW = theBank.GetAccounts().Find(x => x.Id == accountIdW);
                        Console.WriteLine(theBank.Withdraw(foundAccountW, InputDecimal("Deposit amount: ")));
                        Console.ReadKey();
                        break;
                    case "s":
                        PrintListUsers(theBank.GetAccounts());
                        int accountIdS = InputInt("Pick id: ");
                        Account foundAccountS = theBank.GetAccounts().Find(x => x.Id == accountIdS);
                        Console.WriteLine($"{foundAccountS.Name} Balance: {theBank.Balance(foundAccountS)}");
                        Console.ReadKey();
                        break;
                    case "h":
                        Console.WriteLine($"Bank holding: {theBank.BankHolding()}");
                        Console.ReadKey();
                        break;
                    case "b":
                        Console.WriteLine($"Bank name: {theBank.GetBankName()}");
                        Console.ReadKey();
                        break;
                    case "c":
                        theBank.ChargeInterest();
                        break;
                    case "x":
                        runTime = false;
                        break;
                    default:
                        break;
                }

            } while (runTime);
        }
        /// <summary>
        /// Show menu
        /// </summary>
        public static void Menu() 
        {  
            Console.WriteLine("Menu");
            Console.WriteLine("a = Create account");
            Console.WriteLine("d = Deposit");
            Console.WriteLine("w = Witdraw");
            Console.WriteLine("s = Show balance");
            Console.WriteLine("h = BankHolding");
            Console.WriteLine("b = Bank");
            Console.WriteLine("c = ChargeInterest");
            Console.WriteLine("x = Exit");
        }
        /// <summary>
        /// Show account id and name from accountlist
        /// </summary>
        /// <param name="list"></param>
        public static AccountType CreateAccountMenu()
        {
            do
            {
                switch (InputInt("1 = Checking\n2 = Savings\n3 = Costumer "))
                {
                    case 1:
                        return AccountType.Checking;
                    case 2:
                        return AccountType.Savings;
                    case 3:
                        return AccountType.Consumer;
                    default:
                        break;
                }
            } while (true);
        }
        public static void PrintListUsers(List<Account> list)
        {
            foreach (Account account in list)
            {
                Console.WriteLine(account.Id);
                Console.WriteLine(account.Name);
                Console.WriteLine(account.Type);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Writeline for returning only string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
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
        /// <summary>
        /// Writeline for returning only int
        /// </summary>
        /// <param name="text"></param>
        /// <returns>int</returns>
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
        /// <summary>
        /// Writeline for returning only decimal
        /// </summary>
        /// <param name="text"></param>
        /// <returns>decimal</returns>
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



