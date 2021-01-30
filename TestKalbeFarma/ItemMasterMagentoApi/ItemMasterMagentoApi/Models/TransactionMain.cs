using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndKalbeFarm.Models
{
    public class TransactionMain
    {
        public Transaction_Header Tr_Header { get; set; }
        public List<Transaction_Detail> tr_Detail { get; set; }
    }
}
