using System.ComponentModel.DataAnnotations;

namespace SharpBank.API.DTOs.Bank
{
    public class CreateBankDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string CreatedBy { get; set; }
        public decimal SameRTGS { get; set; }
        public decimal SameIMPS { get; set; }
        public decimal SameNEFT { get; set; }
        public decimal OtherRTGS { get; set; }
        public decimal OtherIMPS { get; set; }
        public decimal OtherNEFT { get; set; }

    }
}
