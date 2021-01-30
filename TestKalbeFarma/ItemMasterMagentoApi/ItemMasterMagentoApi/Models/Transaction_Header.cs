using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndKalbeFarm.Models
{
    public class Transaction_Header
    {
        public string Status { get; set; }
        public string InvoiceNo { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDue { get; set; }
        public string PurchaseOrderNo { get; set; }
    }
}
