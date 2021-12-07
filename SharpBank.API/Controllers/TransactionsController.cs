using Microsoft.AspNetCore.Mvc;
using SharpBank.Services.Interfaces;
using SharpBank.Models;
using AutoMapper;
using SharpBank.API.DTOs.Transaction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;

        public TransactionsController(ITransactionService transactionService,IMapper mapper)
        {
            this.transactionService = transactionService;
            this.mapper = mapper;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public IActionResult Get()
        {
            var transactions = transactionService.GetTransactions();
            var transactionsDTO = mapper.Map<IEnumerable<GetTransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var transaction = transactionService.GetTransactionById(id);
            if (transaction == null) {
                return NotFound();
            }
            var transactionDTO = mapper.Map<GetTransactionDTO>(transaction);
            return Ok(transactionDTO);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTransactionDTO transactionDTO)
        {
            try
            {
                if (transactionDTO == null) return BadRequest();
                Transaction transaction = mapper.Map<Transaction>(transactionDTO);
                transaction.TransactionId = Guid.NewGuid();
                Models.Money requiredMoney = new Models.Money { Id=Guid.NewGuid(), Amount = transactionDTO.Amount, Currency = transactionDTO.CurrencyId, FundsId = transactionService.GetFundsId(transaction.DestinationAccountId) };
                var registeredMoney = transactionService.RegisterMoney(requiredMoney);
                transaction.MoneyId = registeredMoney.Id;
                transaction.On=DateTime.Now;   
                var createdTransaction =transactionService.Create(transaction);
                var createdTransactionDTO = mapper.Map<GetTransactionDTO>(createdTransaction);
                return CreatedAtAction(nameof(Get), new { id = createdTransaction.TransactionId},createdTransactionDTO);
            }
            catch (Exception)
            {
                throw;
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
