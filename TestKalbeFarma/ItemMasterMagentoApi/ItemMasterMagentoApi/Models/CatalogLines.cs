using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.Models
{
    public class CatalogLines
    {
        public string Channel { get; set; }
        public string CatalogID { get; set; }
        public string SKUID { get; set; }
        public string SKUName { get; set; }
        public string StyleID { get; set; }
        public string StyleName { get; set; }
        public string ReferenceID { get; set; }
        public string ReferenceName { get; set; }
        public string Currency { get; set; }
        public int PurchQty { get; set; }
        public decimal BonusValue { get; set; }
        public int Stock { get; set; }
        public decimal SalesPrice { get; set; }
        public int CatalogPage { get; set; }
        public string ItemStatus { get; set; }
        public DateTime ItemAktifFrom { get; set; }
        public DateTime ItemAktifTo { get; set; }
        public DateTime HargaAkftifFrom { get; set; }
        public DateTime HargaAktifTo { get; set; }
        public DateTime LastSynchDateTime { get; set; }
        public bool IsCatalogActive { get; set; }
    }
}
