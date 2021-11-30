using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services.Interfaces
{
    public interface IAccountService
    {
        public Account Authenticate(long accountId, string password);
        public IEnumerable<Account> GetAccounts();
        public Account GetAccountById(long accountId);
        
        public Account Create(Account account);
        public Account Update(Account account);
        public Account Delete(long accountId);


    }
}
