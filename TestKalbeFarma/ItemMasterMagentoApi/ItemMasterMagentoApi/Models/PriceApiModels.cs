using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magento2Engine.Model.ApiItemModels
{
    public class PriceApiModels
    {
        [JsonProperty("ItemRelation")]
        public string ItemRelation { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("CatalogId")]
        public string CatalogId { get; set; }

        [JsonProperty("AccountRelation")]
        public string AccountRelation { get; set; }

        [JsonProperty("FromDate")]
        public string FromDate { get; set; }

        [JsonProperty("ToDate")]
        public string ToDate { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("RowID")]
        public long RowId { get; set; }
    }
}
