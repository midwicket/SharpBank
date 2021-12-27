using SharpBank.Models;
using SharpBank.Models.Enums;

namespace SharpBank.API.DTOs.Account
{
    public class GetAccountDTO
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public Guid BankId { get; set; }
        public string Password { get; set; }
        public Guid FundsId { get; set; }
        public Funds Funds { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
    }
}
