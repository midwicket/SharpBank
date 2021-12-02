using Microsoft.AspNetCore.Mvc;
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

        public BanksController(IBankService bankService)
        {
            this.bankService = bankService;
        }
        // GET: api/<BanksController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bankService.GetBanks());
        }


        // GET api/<BanksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = bankService.GetBankById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/<BanksController>
        [HttpPost]
        public IActionResult Post([FromBody] Bank bank)
        {
            try
            {
                if (bank == null) ;
                var createdBank = bankService.Create(bank);
                return CreatedAtAction(nameof(Get), new { id=createdBank.BankId}, createdBank);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<BanksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] string value)
        {
            return BadRequest();
        }

        // DELETE api/<BanksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return BadRequest();
        }
    }
}
