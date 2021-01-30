using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndKalbeFarm.Models
{
    public class Transaction_Detail
    {
        public string ItemName { get; set; }
        public decimal qty { get; set; }
        public decimal rate { get; set; }
        public decimal Amount { get; set; }
        public string TypeRate { get; set; }
        public string TypeDiscount { get; set; }
        public string DiscountValue { get; set; }
        public decimal AmountDiscount { get; set; }

    }
}
