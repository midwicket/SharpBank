using SharpBank.Models;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models.Exceptions;



namespace SharpBank.CLI.Controllers
{
     class BanksController
    {
        private readonly BankService bankService;
        private readonly Inputs inputs;

        public BanksController(BankService bankService,Inputs inputs)
        {
            this.bankService = bankService;
            this.inputs = inputs;
        }

        public long CreateBank(string v) {
            long id=0;
            try
            {
                string name = v;
                id =bankService.AddBank(name);
           
            }
            catch (BankIdException e)
            {

                Console.WriteLine("Bank already exists.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return id;


        }
        public Bank GetBank(long bankId)
        {

            try
            {
                Bank b=bankService.GetBank(bankId);
                if(b==null)
                {
                    throw new BankIdException();
                }
                return b;
            }
            catch (BankIdException e)
            {

                Console.WriteLine("Bank does not exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
    }
}
