using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank.DAL;

namespace TheBank.Repository
{
    internal class RepoInput : IInput
    {
        public string InputString(string text)
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
        public int InputInt(string text)
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
        public decimal InputDecimal(string text)
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
        public AccountType CreateAccountMenu()
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
        public void PrintListUsers(List<AccountListItem> list)
        {
            foreach (var account in list)
            {
                Console.WriteLine($"Id: {account.Id}");
                Console.WriteLine($"Name: {account.Name}");
                Console.WriteLine($"Type: {account.Type}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine();
            }
        }
    }
}
