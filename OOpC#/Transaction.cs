using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOpC_
{
        internal class Transaction
        {
            public decimal Amount { get; set; }
            public DateTime OperationDate { get; set; }
            public string Description { get; set; } = "Operazione";

            public Transaction(decimal amount, string description = null)
            {
                Amount = amount;
                OperationDate = DateTime.Now;
                Description = description ?? Description;
            }
        }
 }

