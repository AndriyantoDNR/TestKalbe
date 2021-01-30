using Magento2Engine.Model.ApiItemModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.Models
{
    public class ApiItemMasterModels
    {
        [JsonProperty("CatalogID")]
        public string CatalogId { get; set; }
        
        [JsonProperty("SKUID")]
        public string Skuid { get; set; }
        public String TypeProduct { get; set; }
     
        public string BV { get; set; }

        [JsonProperty("SKUName")]
        public string SkuName { get; set; }

   
        public string AttributeId { get; set; }

        [JsonProperty("StyleID")]
        public string StyleId { get; set; }

        [JsonProperty("StyleName")]
        public string StyleName { get; set; }

        [JsonProperty("ReferenceID")]
        public string ReferenceId { get; set; }

        [JsonProperty("ReferenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("SalesPrice")]
        public string SalesPrice { get; set; }

        [JsonProperty("PurchQty")]
        public string PurchQty { get; set; }

        [JsonProperty("BonusValue")]
        public string BonusValue { get; set; }

        [JsonProperty("Stock")]
        public string Stock { get; set; }

        //tambahaan 27 august
        public string itemstatus { get; set; }
        public string syncDate { get; set; }


        [JsonProperty("SKUs")]
        public SkUsApiModels SkuModels { get; set; }
        [JsonProperty("Styles")]
        public StylesApiModels StylesModels { get; set; }
        [JsonProperty("Prices")]
        public List<PriceApiModels> PriceModels { get; set; }
    }
}
