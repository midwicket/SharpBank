using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharpBank.API.DTOs.Bank;
using SharpBank.Models;
using SharpBank.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService bankService;
        private readonly IMapper mapper;

        public BanksController(IBankService bankService, IMapper mapper)
        {
            this.bankService = bankService;
            this.mapper = mapper;
        }
        // GET: api/<BanksController>
        [HttpGet]
        public IActionResult Get()
        {
            var bankDTOs = mapper.Map<IEnumerable<GetBankDTO>>(bankService.GetBanks());
            return Ok(bankDTOs);
        }


        // GET api/<BanksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var bank = bankService.GetBankById(id);
            if (bank == null) return NotFound();


            var bankDTO = mapper.Map<GetBankDTO>(bank);

            var same = bankService.GetTransactionChargeByName(bank.BankId, "Same");
            var other = bankService.GetTransactionChargeByName(bank.BankId, "Other");

            bankDTO.SameIMPS = same.IMPS;
            bankDTO.SameRTGS = same.RTGS;
            bankDTO.SameNEFT = same.NEFT;
            bankDTO.OtherIMPS = other.IMPS;
            bankDTO.OtherRTGS = other.RTGS;
            bankDTO.OtherNEFT = other.NEFT;

            return Ok(bankDTO);
        }

        // POST api/<BanksController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBankDTO bankDTO)
        {
            try
            {
                if (bankDTO == null)return BadRequest();

                var bank = mapper.Map<Bank>(bankDTO);
                bank.BankId = Guid.NewGuid();
                bank.CreatedOn = DateTime.Now;
                bank.UpdatedOn = DateTime.Now;
                bank.UpdatedBy = bank.CreatedBy;
                var same = bankService.CreateTransactionCharge(bank, bankDTO.SameRTGS, bankDTO.SameIMPS, bankDTO.SameNEFT,"Same");
                var other = bankService.CreateTransactionCharge(bank, bankDTO.OtherRTGS, bankDTO.OtherIMPS, bankDTO.OtherNEFT,"Other");

                var createdBank = bankService.Create(bank);
                var createdBankDTO = mapper.Map<GetBankDTO>(createdBank);
                createdBankDTO.SameIMPS = same.IMPS;
                createdBankDTO.SameRTGS = same.RTGS;
                createdBankDTO.SameNEFT = same.NEFT;
                createdBankDTO.OtherIMPS = other.IMPS;
                createdBankDTO.OtherRTGS = other.RTGS;
                createdBankDTO.OtherNEFT = other.NEFT;


                return CreatedAtAction(nameof(Get), new { id=createdBank.BankId}, createdBankDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<BanksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateBankDTO bankDTO)
        {
            try
            {
                if (bankDTO == null) return BadRequest(bankDTO);
                var oldBank = bankService.GetBankById(id);
                if (oldBank == null) return BadRequest(bankDTO);
                var bank = mapper.Map<Bank>(bankDTO);
                bank.BankId = id;
                bank.CreatedBy = oldBank.CreatedBy;
                bank.CreatedOn = oldBank.CreatedOn;
                bank.UpdatedOn = DateTime.Now;
                var same = bankService.UpdateTransactionCharge(bank, bankDTO.SameRTGS, bankDTO.SameIMPS, bankDTO.SameNEFT, "Same");
                var other = bankService.UpdateTransactionCharge(bank, bankDTO.OtherRTGS, bankDTO.OtherIMPS, bankDTO.OtherNEFT, "Other");

                var updatedBank = bankService.Update(bank);
                var updatedBankDTO = mapper.Map<GetBankDTO>(updatedBank);
                updatedBankDTO.SameIMPS = same.IMPS;
                updatedBankDTO.SameRTGS = same.RTGS;
                updatedBankDTO.SameNEFT = same.NEFT;
                updatedBankDTO.OtherIMPS = other.IMPS;
                updatedBankDTO.OtherRTGS = other.RTGS;
                updatedBankDTO.OtherNEFT = other.NEFT;
                return Ok(updatedBankDTO);
            }
            catch {
                return BadRequest(bankDTO);
            }
        }

        // DELETE api/<BanksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deletedBank = bankService.Delete(id);
                return Ok(deletedBank);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
