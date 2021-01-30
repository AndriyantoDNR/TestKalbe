using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.Models
{
    public class Prices
    {
        public string ItemRelation { get; set; }
        public string AccountRelation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string CatalogID { get; set; }
        public DateTime LastSynchDateTime { get; set; }
    }
}
