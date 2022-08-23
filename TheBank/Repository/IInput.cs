using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank.DAL;

namespace TheBank.Repository
{
    public interface IInput
    {
        public string InputString(string text);
        public int InputInt(string text);
        public decimal InputDecimal(string text);
        public AccountType CreateAccountMenu();
        public void PrintListUsers(List<AccountListItem> list);
    }
}
