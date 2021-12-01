using Microsoft.AspNetCore.Mvc;
using SharpBank.API.Services.Interfaces;
using SharpBank.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(transactionService.GetTransactions());
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = transactionService.GetTransactionById(id);
            if (result == null) {

                return NotFound();
                
            }
            return Ok(result);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            try
            {
                if (transaction == null) return BadRequest();
                var t =transactionService.Create(transaction);
                return CreatedAtAction(nameof(Get), new { id = t.TransactionId},t);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Transaction transaction)
        {


        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var t = transactionService.Delete(id);
                return Ok(t);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
