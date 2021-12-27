using SharpBank.Models;
using System.ComponentModel.DataAnnotations;

namespace SharpBank.API.DTOs.Bank
{
    public class UpdateBankDTO
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string UpdatedBy { get; set; }
        public decimal SameRTGS { get; set; }
        public decimal SameIMPS { get; set; }
        public decimal SameNEFT { get; set; }
        public decimal OtherRTGS { get; set; }
        public decimal OtherIMPS { get; set; }
        public decimal OtherNEFT { get; set; }

    }
}
