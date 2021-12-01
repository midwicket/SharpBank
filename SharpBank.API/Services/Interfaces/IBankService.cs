using SharpBank.Models;

namespace SharpBank.API.Services.Interfaces
{
    public interface IBankService
    {
        public IEnumerable<Bank> GetBanks();
        public Bank GetBankById(Guid Id);
        public Bank GetBankByName(string bankName);

        public Bank Create(Bank bank);
        public Bank Update(Bank bank);
        public void Delete(Guid Id);
    }
}
