﻿using Microsoft.AspNetCore.Mvc;
using SharpBank.Services.Interfaces;
using SharpBank.Models;
using AutoMapper;
using SharpBank.API.DTOs.Account;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountsController(IAccountService accountService,IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }
        // GET: api/<AccountsController>
        [Authorize(Roles = "Staff")]
        [HttpGet]
        public IActionResult Get()
        {
            var accountsDTO = mapper.Map<IEnumerable<GetAccountDTO>>(accountService.GetAccounts());
            return Ok(accountsDTO);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var account =accountService.GetAccountById(id);
            if (account == null) return NotFound();
            var accountDTO = mapper.Map<GetAccountDTO>(account);
            return Ok(accountDTO);
        }
        // POST api/<AccountsController>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Post([FromBody] AuthenticateAccountDTO accountDTO)
        {
            var token = accountService.Authenticate(accountDTO.AccountId, accountDTO.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
            
        }


        // POST api/<AccountsController>
        [Authorize(Roles = "Staff")]
        [HttpPost("{bankId}")]
        public IActionResult Post(Guid bankId,[FromBody] CreateAccountDTO accountDTO )
        {
            try
            {
                if (accountDTO == null) return BadRequest();
                Account account = mapper.Map<Account>(accountDTO);
                account.AccountId=Guid.NewGuid();
                account.BankId = bankId;
                account.Status = Models.Enums.Status.Active;
                Funds funds = new Funds
                {
                    Id = Guid.NewGuid()
                };
                account.FundsId = accountService.CreateFunds(funds).Id;

                var createdAccount = accountService.Create(account);
                var createdAccountDTO = mapper.Map<GetAccountDTO>(createdAccount);
                return CreatedAtAction(nameof(Get), new { id = createdAccount.AccountId }, createdAccountDTO);
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
        [Authorize(Roles = "Staff")]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
