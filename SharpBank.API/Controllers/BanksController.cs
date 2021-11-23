using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SharpBank.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        // GET: api/<BanksController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Bank> banks = new List<Bank>();

            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=asp;pwd=asp;database=sharpbank;pooling = false; convert zero datetime=True")) {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM bank;";
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank bank = new Bank();
                    bank.id = Convert.ToInt32(reader["id"]);
                    bank.name = reader["name"].ToString();
                    bank.created_by = reader["created_by"].ToString();
                    bank.updated_by = reader["updated_by"].ToString();
                    bank.updated_on = (DateTime)reader["updated_on"];
                    bank.created_on = (DateTime)reader["created_on"];
                    bank.transaction_charges_id = Convert.ToInt32(reader["transaction_charges_id"]);
                    bank.logo = reader["logo"].ToString();

                    banks.Add(bank);

                }
            }


            return Ok(banks);
        }

        // GET api/<BanksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Bank bank = new Bank();
            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=asp;pwd=asp;database=sharpbank;pooling = false; convert zero datetime=True"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"SELECT * FROM bank WHERE bank.id={id};";
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    bank.id = Convert.ToInt32(reader["id"]);
                    bank.name = reader["name"].ToString();
                    bank.created_by = reader["created_by"].ToString();
                    bank.updated_by = reader["updated_by"].ToString();
                    bank.updated_on = (DateTime)reader["updated_on"];
                    bank.created_on = (DateTime)reader["created_on"];
                    bank.transaction_charges_id = Convert.ToInt32(reader["transaction_charges_id"]);
                    bank.logo = reader["logo"].ToString();
                     
                    

                }
            }
            return Ok(bank);
        }


        // POST api/<BanksController>
        [HttpPost]
        public IActionResult Post([FromBody] Bank value)
        {
            Bank bank = new Bank();
            bank.name = value.name;
            bank.created_by = "Scamananda Scambabu";
            bank.updated_by = "Scamananda Scambabu";
            bank.transaction_charges_id = 1;
            var sql = $"INSERT INTO `bank` (`id`, `name`, `logo`, `created_on`, `created_by`, `updated_on`, `updated_by`, `transaction_charges_id`) VALUES (NULL, '{bank.name}', '/css/images/{bank.name}.png', current_timestamp(), '{bank.created_by}', '0000-00-00 00:00:00.000000', '{bank.updated_by}', {bank.transaction_charges_id})";


            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=asp;pwd=asp;database=sharpbank;pooling = false; convert zero datetime=True"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            return Ok(bank);
        }

        // PUT api/<BanksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BanksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=asp;pwd=asp;database=sharpbank;pooling = false; convert zero datetime=True"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"DELETE FROM bank WHERE bank.id={id};";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
