using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharpBank.Data;
using SharpBank.Models;
using SharpBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext appDbContext;

        public AccountService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string Authenticate(Guid accountId, string password)
        {
            Account account = appDbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId && a.Password == password);
            if (account == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("MirchiBajjiManoharRaoKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{ 
                    new Claim(ClaimTypes.Name,account.AccountId.ToString()),
                    new Claim(ClaimTypes.Role,account.Status.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = 
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public Account Create(Account account)
        {
            appDbContext.Accounts.Add(account);
            appDbContext.SaveChanges();
            return account;
        }

        public Funds CreateFunds(Funds funds)
        {
            appDbContext.FundsTable.Add(funds);
            appDbContext.SaveChanges();
            return appDbContext.FundsTable.SingleOrDefault(f => f.Id == funds.Id);
        }

        public Account Delete(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(Guid accountId)
        {
            var res = appDbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            return res;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return appDbContext.Accounts
                .Include(a => a.Funds)
                .ThenInclude(f => f.Wallets)
                .Include(a => a.CreditTransactions)
                .Include(a => a.DebitTransactions)
                .ToList();
        }

        public Account Update(Account account)
        {
            appDbContext.Accounts.Attach(account);
            appDbContext.SaveChanges();
            return account;
        }
    }

}
