using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOpC_
{
    internal class Transaction
    {
       
        public int Amount {  get; set; }
        public DateTime OperationDate { get; set; }

        public Transaction(int amount, DateTime operationDate)
        {
            Amount = amount;
            OperationDate = operationDate;
        }
    }
}
