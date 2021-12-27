﻿using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpBank.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
        public string Password { get; set; }
        public Guid FundsId { get; set; }
        public Funds Funds { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }

        public ICollection<Transaction> CreditTransactions { get; set; }
        public ICollection<Transaction> DebitTransactions { get; set; }
    }
}
