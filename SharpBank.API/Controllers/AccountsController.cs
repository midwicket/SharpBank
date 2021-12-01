using Microsoft.AspNetCore.Mvc;
using SharpBank.API.Services.Interfaces;
using SharpBank.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(accountService.GetAccounts());
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result =accountService.GetAccountById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public IActionResult Post([FromBody] Account account )
        {
            try
            {
                if (account == null) return BadRequest();
                var createdAccount = accountService.Create(account);
                return CreatedAtAction(nameof(Get), new { id = createdAccount.AccountId }, createdAccount);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
