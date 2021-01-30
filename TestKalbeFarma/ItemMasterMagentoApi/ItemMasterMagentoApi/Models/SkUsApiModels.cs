using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magento2Engine.Model.ApiItemModels
{
    public class SkUsApiModels
    {
        [JsonProperty("SKUID")]
        public string Skuid { get; set; }

        public string sizeId { get; set; }
        [JsonProperty("SKUName")]
        public string SkuName { get; set; }

        public string subcategory { get; set; }
        [JsonProperty("Catalog")]
        public string Catalog { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }

        [JsonProperty("ItemGroup")]
        public string ItemGroup { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("C1")]
        public string C1 { get; set; }

        [JsonProperty("C2")]
        public string C2 { get; set; }

        [JsonProperty("C3")]
        public string C3 { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Age")]
        public string Age { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DescriptionEN")]
        public string DescriptionEn { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("MarketingColor")]
        public string MarketingColor { get; set; }

        [JsonProperty("Config")]
        public object Config { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }

        [JsonProperty("Dimension")]
        public string Dimension { get; set; }

        [JsonProperty("Material")]
        public string Material { get; set; }

        [JsonProperty("BodyShape")]
        public object BodyShape { get; set; }

        [JsonProperty("Fitting")]
        public object Fitting { get; set; }

        [JsonProperty("StyleID")]
        public string StyleId { get; set; }

        [JsonProperty("StyleName")]
        public string StyleName { get; set; }

        [JsonProperty("ImagePath")]
        public string ImagePath { get; set; }

        [JsonProperty("ReferenceID")]
        public string ReferenceId { get; set; }

        [JsonProperty("ReferenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("RowID")]
        public long RowId { get; set; }
    }
}
