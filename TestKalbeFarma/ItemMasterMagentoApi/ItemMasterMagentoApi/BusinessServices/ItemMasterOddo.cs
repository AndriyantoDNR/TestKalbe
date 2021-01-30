using ItemMasterMagentoApi.Models;
using Magento2Engine.Model.ApiItemModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.BusinessServices
{
    public class ItemMasterOddo : RepositoryItemMasterOddo
    {
        string cnnString = "Server=52.187.160.192;Initial Catalog=ODOOITEM;Persist Security Info=False;User ID=rwservice;Password=SophieHappy33;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=3600;";


        public async Task<List<ApiItemMasterModels>> GetAllItemMaster(string CatalogId)
        {
            List<ApiItemMasterModels> ModelList = new List<ApiItemMasterModels>();
            List<ApiItemMasterModels> ModelListMapping = new List<ApiItemMasterModels>();

            try
            {

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ItemMaster_OmniRetail_temp";
                //cmd.Parameters.Add(new SqlParameter("@CatalogId", CatalogId));
                cnn.Open();
                int i = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Map data to Order class using this way
                    // orders = DataReaderMapToList<AllItemApiModels>(reader).ToList();
                    while (reader.Read())
                    {
                        ApiItemMasterModels Model = new ApiItemMasterModels();
                        Model.TypeProduct = reader["typeproduct"].ToString();
                        Model.CatalogId = reader["CatalogID"].ToString();
                        Model.Skuid = reader["SKUID"].ToString();
                        Model.SkuName = reader["SKUName"].ToString();
                        Model.StyleId = reader["StyleID"].ToString();
                        Model.StyleName = reader["StyleName"].ToString();
                        Model.ReferenceId = reader["ReferenceID"].ToString();
                        Model.ReferenceName = reader["ReferenceName"].ToString();
                        Model.Currency = reader["Currency"].ToString();
                        Model.SalesPrice = reader["SalesPrice"].ToString();
                        Model.PurchQty = reader["PurchQty"].ToString();
                        Model.BonusValue = reader["BonusValue"].ToString();
                        Model.Stock = reader["stock"].ToString();
                        Model.itemstatus = reader["ItemStatus"].ToString();
                        Model.syncDate = reader["LastSynchDateTime"].ToString();

                        SkUsApiModels SkuModels = new SkUsApiModels();
                        SkuModels.Skuid = reader["sku_skuid"].ToString();
                        SkuModels.SkuName = reader["sku_skuname"].ToString();
                        SkuModels.Catalog = reader["sku_catalog"].ToString();
                        SkuModels.Department = reader["sku_Department"].ToString();
                        SkuModels.ItemGroup = reader["sku_ItemGroup"].ToString();
                        SkuModels.Brand = reader["sku_brand"].ToString();
                        SkuModels.C1 = reader["sku_C1"].ToString();
                        SkuModels.C2 = reader["sku_C2"].ToString();
                        SkuModels.C3 = reader["sku_C3"].ToString();
                        SkuModels.Gender = reader["sku_Gender"].ToString();
                        SkuModels.Age = reader["sku_Age"].ToString();
                        SkuModels.Description = reader["sku_description"].ToString();   
                        SkuModels.DescriptionEn = reader["sku_descriptionEn"].ToString();
                        SkuModels.Color = reader["sku_color"].ToString();
                        SkuModels.MarketingColor = reader["sku_marketingcolorcolor"].ToString();
                        SkuModels.Size = reader["sku_size"].ToString();
                        SkuModels.Dimension = reader["sku_dimension"].ToString();
                        SkuModels.Material = reader["sku_material"].ToString();
                        SkuModels.BodyShape = reader["sku_bodyshape"].ToString();
                        SkuModels.Fitting = reader["sku_fitting"].ToString();
                        SkuModels.StyleId = reader["sku_styleid"].ToString();
                        SkuModels.StyleName = reader["sku_stylename"].ToString();
                        SkuModels.ImagePath = reader["sku_ImagePath"].ToString();
                        SkuModels.ReferenceId = reader["sku_referenceid"].ToString();
                        SkuModels.ReferenceName = reader["sku_referencename"].ToString();
                        Model.SkuModels = SkuModels;

                        StylesApiModels StyleModels = new StylesApiModels();
                        StyleModels.StyleId = reader["style_StyleId"].ToString();
                        StyleModels.StyleName = reader["style_styleName"].ToString();
                        StyleModels.Catalog = reader["style_catalog"].ToString();
                        StyleModels.Department = reader["style_department"].ToString();
                        StyleModels.ItemGroup = reader["style_itemgroup"].ToString();
                        StyleModels.Brand = reader["style_brand"].ToString();
                        StyleModels.C1 = reader["style_c1"].ToString();
                        StyleModels.C2 = reader["style_c2"].ToString();
                        StyleModels.C3 = reader["style_c3"].ToString();
                        StyleModels.Gender = reader["style_gender"].ToString();
                        StyleModels.Description = reader["style_description"].ToString();
                        StyleModels.DescriptionEn = reader["style_descriptionEn"].ToString();
                        Model.StylesModels = StyleModels;

                        List<PriceApiModels> ListPrice = new List<PriceApiModels>();
                        PriceApiModels PriceModels = new PriceApiModels();
                        PriceModels.ItemRelation = reader["ItemRelation"].ToString();
                        PriceModels.Currency = reader["Currency"].ToString();
                        PriceModels.CatalogId = reader["CatalogID"].ToString();
                        PriceModels.AccountRelation = reader["AccountRelation"].ToString();
                        PriceModels.FromDate = reader["FromDate"].ToString();
                        PriceModels.ToDate = reader["ToDate"].ToString();
                        PriceModels.Amount = reader["Amount"].ToString();
                        ListPrice.Add(PriceModels);
                        Model.PriceModels = ListPrice;

                        ModelList.Add(Model);
                    }

                    ModelListMapping = MappingItemMaster(ModelList);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return ModelList.ToList() ;
        }

        public List<ApiItemMasterModels> MappingItemMaster(List<ApiItemMasterModels> ListData)
        {
            List<ApiItemMasterModels> ListItemMap = new List<ApiItemMasterModels>();
            try
            {
                var Catalog = (from a in ListData select a.CatalogId).ToList().Distinct();
                foreach (var catalog in Catalog)
                {
                    var SKus = (from a in ListData where a.CatalogId == catalog select a.Skuid).ToList().Distinct();
                    foreach (var a in SKus)
                    {
                        ApiItemMasterModels ItemMasterMain = new ApiItemMasterModels();
                       
                        ItemMasterMain.Skuid = a.ToString();
                        ItemMasterMain.TypeProduct = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.SkuName) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.TypeProduct).FirstOrDefault().ToString();
                        ItemMasterMain.SkuName = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.SkuName) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.SkuName).FirstOrDefault().ToString();
                        ItemMasterMain.StyleId = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleId) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleId).FirstOrDefault().ToString();
                        ItemMasterMain.StyleName = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleName) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleName).FirstOrDefault().ToString();
                        ItemMasterMain.ReferenceId = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.ReferenceId) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.ReferenceId).FirstOrDefault().ToString();
                        ItemMasterMain.ReferenceName = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleId) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.StyleId).FirstOrDefault().ToString();
                        ItemMasterMain.Currency = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.Currency) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.Currency).FirstOrDefault().ToString();
                        ItemMasterMain.SalesPrice = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.SalesPrice) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.SalesPrice).FirstOrDefault().ToString();
                        ItemMasterMain.PurchQty = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.PurchQty) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.PurchQty).FirstOrDefault().ToString();
                        ItemMasterMain.BonusValue = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.BonusValue) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.BonusValue).FirstOrDefault().ToString();
                        ItemMasterMain.Stock = ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.Stock) == null ? "" : ListData.Where(b => b.Skuid == a.ToString()).Select(z => z.Stock).FirstOrDefault().ToString();



                        SkUsApiModels Sku = new SkUsApiModels();
                       
                        Sku.Skuid = a;
                        Sku.SkuName = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuName) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuName).FirstOrDefault().ToString();
                        Sku.Catalog = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.CatalogId) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.CatalogId).FirstOrDefault().ToString();
                        Sku.Department = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Department) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Department).FirstOrDefault().ToString();
                        Sku.ItemGroup = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.ItemGroup) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Department).FirstOrDefault().ToString();
                        Sku.Brand = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Brand) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Brand).FirstOrDefault().ToString();
                        Sku.C1 = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C1) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C1).FirstOrDefault().ToString();
                        Sku.C2 = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C2) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C2).FirstOrDefault().ToString();
                        Sku.C3 = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C3) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.C3).FirstOrDefault().ToString();
                        Sku.Gender = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Gender) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Gender).FirstOrDefault().ToString();
                        Sku.Age = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Age) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Age).FirstOrDefault().ToString();
                        Sku.Description = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Description) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Description).FirstOrDefault().ToString();
                        Sku.DescriptionEn = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.DescriptionEn) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.DescriptionEn).FirstOrDefault().ToString();
                        Sku.Color = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Color) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Color).FirstOrDefault().ToString();
                        Sku.MarketingColor = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.MarketingColor) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.MarketingColor).FirstOrDefault().ToString();
                        Sku.Size = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Size) == null ? "" : ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.SkuModels.Size).FirstOrDefault().ToString();
                        ItemMasterMain.SkuModels = Sku;

                        StylesApiModels Style = new StylesApiModels();
                        Style = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.StylesModels).FirstOrDefault();
                        ItemMasterMain.StylesModels = Style;

                        List<PriceApiModels> price = new List<PriceApiModels>();
                        price = ListData.Where(b => b.Skuid == a.ToString() && b.CatalogId == catalog).Select(z => z.PriceModels).ToList().FirstOrDefault();
                        ItemMasterMain.PriceModels = price;

                        ListItemMap.Add(ItemMasterMain);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ListItemMap;
        }


        public async Task<List<ApiItemMasterModels>> GetAllItemMasterByReferenceid(string Referenceid)
        {
            List<ApiItemMasterModels> ModelList = new List<ApiItemMasterModels>();
            List<ApiItemMasterModels> ModelListMapping = new List<ApiItemMasterModels>();

            try
            {

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ItemMaster_OmniRetail_by_referenceid";
                cmd.Parameters.Add(new SqlParameter("@Referenceid", Referenceid));
                cnn.Open();
                int i = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Map data to Order class using this way
                    // orders = DataReaderMapToList<AllItemApiModels>(reader).ToList();
                    while (reader.Read())
                    {
                        ApiItemMasterModels Model = new ApiItemMasterModels();
                        Model.TypeProduct = reader["typeproduct"].ToString();
                        Model.CatalogId = reader["CatalogID"].ToString();
                        Model.Skuid = reader["SKUID"].ToString();
                        Model.SkuName = reader["SKUName"].ToString();
                        Model.StyleId = reader["StyleID"].ToString();
                        Model.StyleName = reader["StyleName"].ToString();
                        Model.ReferenceId = reader["ReferenceID"].ToString();
                        Model.ReferenceName = reader["ReferenceName"].ToString();
                        Model.Currency = reader["Currency"].ToString();
                        Model.SalesPrice = reader["SalesPrice"].ToString();
                        Model.PurchQty = reader["PurchQty"].ToString();
                        Model.BonusValue = reader["BonusValue"].ToString();
                        Model.Stock = reader["stock"].ToString();
                        Model.itemstatus = reader["ItemStatus"].ToString();
                        Model.syncDate = reader["LastSynchDateTime"].ToString();

                        SkUsApiModels SkuModels = new SkUsApiModels();
                        SkuModels.Skuid = reader["sku_skuid"].ToString();
                        SkuModels.SkuName = reader["sku_skuname"].ToString();
                        SkuModels.Catalog = reader["sku_catalog"].ToString();
                        SkuModels.Department = reader["sku_Department"].ToString();
                        SkuModels.ItemGroup = reader["sku_ItemGroup"].ToString();
                        SkuModels.Brand = reader["sku_brand"].ToString();
                        SkuModels.C1 = reader["sku_C1"].ToString();
                        SkuModels.C2 = reader["sku_C2"].ToString();
                        SkuModels.C3 = reader["sku_C3"].ToString();
                        SkuModels.Gender = reader["sku_Gender"].ToString();
                        SkuModels.Age = reader["sku_Age"].ToString();
                        SkuModels.Description = reader["sku_description"].ToString();
                        SkuModels.DescriptionEn = reader["sku_descriptionEn"].ToString();
                        SkuModels.Color = reader["sku_color"].ToString();
                        SkuModels.MarketingColor = reader["sku_marketingcolorcolor"].ToString();
                        SkuModels.Size = reader["sku_size"].ToString();
                        SkuModels.Dimension = reader["sku_dimension"].ToString();
                        SkuModels.Material = reader["sku_material"].ToString();
                        SkuModels.BodyShape = reader["sku_bodyshape"].ToString();
                        SkuModels.Fitting = reader["sku_fitting"].ToString();
                        SkuModels.StyleId = reader["sku_styleid"].ToString();
                        SkuModels.StyleName = reader["sku_stylename"].ToString();
                        SkuModels.ImagePath = reader["sku_ImagePath"].ToString();
                        SkuModels.ReferenceId = reader["sku_referenceid"].ToString();
                        SkuModels.ReferenceName = reader["sku_referencename"].ToString();
                        Model.SkuModels = SkuModels;

                        StylesApiModels StyleModels = new StylesApiModels();
                        StyleModels.StyleId = reader["style_StyleId"].ToString();
                        StyleModels.StyleName = reader["style_styleName"].ToString();
                        StyleModels.Catalog = reader["style_catalog"].ToString();
                        StyleModels.Department = reader["style_department"].ToString();
                        StyleModels.ItemGroup = reader["style_itemgroup"].ToString();
                        StyleModels.Brand = reader["style_brand"].ToString();
                        StyleModels.C1 = reader["style_c1"].ToString();
                        StyleModels.C2 = reader["style_c2"].ToString();
                        StyleModels.C3 = reader["style_c3"].ToString();
                        StyleModels.Gender = reader["style_gender"].ToString();
                        StyleModels.Description = reader["style_description"].ToString();
                        StyleModels.DescriptionEn = reader["style_descriptionEn"].ToString();
                        Model.StylesModels = StyleModels;

                        List<PriceApiModels> ListPrice = new List<PriceApiModels>();
                        PriceApiModels PriceModels = new PriceApiModels();
                        PriceModels.ItemRelation = reader["ItemRelation"].ToString();
                        PriceModels.Currency = reader["Currency"].ToString();
                        PriceModels.CatalogId = reader["CatalogID"].ToString();
                        PriceModels.AccountRelation = reader["AccountRelation"].ToString();
                        PriceModels.FromDate = reader["FromDate"].ToString();
                        PriceModels.ToDate = reader["ToDate"].ToString();
                        PriceModels.Amount = reader["Amount"].ToString();
                        ListPrice.Add(PriceModels);
                        Model.PriceModels = ListPrice;

                        ModelList.Add(Model);
                    }

                    ModelListMapping = MappingItemMaster(ModelList);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return ModelList.ToList();
        }

        public async Task<List<ApiItemMasterModels>> GetAllItemMasterBySkuid(string skuid)
        {
            List<ApiItemMasterModels> ModelList = new List<ApiItemMasterModels>();
            List<ApiItemMasterModels> ModelListMapping = new List<ApiItemMasterModels>();

            try
            {

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ItemMaster_OmniRetail_by_SKU";
                cmd.Parameters.Add(new SqlParameter("@skuid", skuid));
                cnn.Open();
                int i = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Map data to Order class using this way
                    // orders = DataReaderMapToList<AllItemApiModels>(reader).ToList();
                    while (reader.Read())
                    {
                        ApiItemMasterModels Model = new ApiItemMasterModels();
                        Model.TypeProduct = reader["typeproduct"].ToString();
                        Model.CatalogId = reader["CatalogID"].ToString();
                        Model.Skuid = reader["SKUID"].ToString();
                        Model.SkuName = reader["SKUName"].ToString();
                        Model.StyleId = reader["StyleID"].ToString();
                        Model.StyleName = reader["StyleName"].ToString();
                        Model.ReferenceId = reader["ReferenceID"].ToString();
                        Model.ReferenceName = reader["ReferenceName"].ToString();
                        Model.Currency = reader["Currency"].ToString();
                        Model.SalesPrice = reader["SalesPrice"].ToString();
                        Model.PurchQty = reader["PurchQty"].ToString();
                        Model.BonusValue = reader["BonusValue"].ToString();
                        Model.Stock = reader["stock"].ToString();
                        Model.itemstatus = reader["ItemStatus"].ToString();
                        Model.syncDate = reader["LastSynchDateTime"].ToString();

                        SkUsApiModels SkuModels = new SkUsApiModels();
                        SkuModels.Skuid = reader["sku_skuid"].ToString();
                        SkuModels.SkuName = reader["sku_skuname"].ToString();
                        SkuModels.Catalog = reader["sku_catalog"].ToString();
                        SkuModels.Department = reader["sku_Department"].ToString();
                        SkuModels.ItemGroup = reader["sku_ItemGroup"].ToString();
                        SkuModels.Brand = reader["sku_brand"].ToString();
                        SkuModels.C1 = reader["sku_C1"].ToString();
                        SkuModels.C2 = reader["sku_C2"].ToString();
                        SkuModels.C3 = reader["sku_C3"].ToString();
                        SkuModels.Gender = reader["sku_Gender"].ToString();
                        SkuModels.Age = reader["sku_Age"].ToString();
                        SkuModels.Description = reader["sku_description"].ToString();
                        SkuModels.DescriptionEn = reader["sku_descriptionEn"].ToString();
                        SkuModels.Color = reader["sku_color"].ToString();
                        SkuModels.MarketingColor = reader["sku_marketingcolorcolor"].ToString();
                        SkuModels.Size = reader["sku_size"].ToString();
                        SkuModels.Dimension = reader["sku_dimension"].ToString();
                        SkuModels.Material = reader["sku_material"].ToString();
                        SkuModels.BodyShape = reader["sku_bodyshape"].ToString();
                        SkuModels.Fitting = reader["sku_fitting"].ToString();
                        SkuModels.StyleId = reader["sku_styleid"].ToString();
                        SkuModels.StyleName = reader["sku_stylename"].ToString();
                        SkuModels.ImagePath = reader["sku_ImagePath"].ToString();
                        SkuModels.ReferenceId = reader["sku_referenceid"].ToString();
                        SkuModels.ReferenceName = reader["sku_referencename"].ToString();
                        Model.SkuModels = SkuModels;

                        StylesApiModels StyleModels = new StylesApiModels();
                        StyleModels.StyleId = reader["style_StyleId"].ToString();
                        StyleModels.StyleName = reader["style_styleName"].ToString();
                        StyleModels.Catalog = reader["style_catalog"].ToString();
                        StyleModels.Department = reader["style_department"].ToString();
                        StyleModels.ItemGroup = reader["style_itemgroup"].ToString();
                        StyleModels.Brand = reader["style_brand"].ToString();
                        StyleModels.C1 = reader["style_c1"].ToString();
                        StyleModels.C2 = reader["style_c2"].ToString();
                        StyleModels.C3 = reader["style_c3"].ToString();
                        StyleModels.Gender = reader["style_gender"].ToString();
                        StyleModels.Description = reader["style_description"].ToString();
                        StyleModels.DescriptionEn = reader["style_descriptionEn"].ToString();
                        Model.StylesModels = StyleModels;

                        List<PriceApiModels> ListPrice = new List<PriceApiModels>();
                        PriceApiModels PriceModels = new PriceApiModels();
                        PriceModels.ItemRelation = reader["ItemRelation"].ToString();
                        PriceModels.Currency = reader["Currency"].ToString();
                        PriceModels.CatalogId = reader["CatalogID"].ToString();
                        PriceModels.AccountRelation = reader["AccountRelation"].ToString();
                        PriceModels.FromDate = reader["FromDate"].ToString();
                        PriceModels.ToDate = reader["ToDate"].ToString();
                        PriceModels.Amount = reader["Amount"].ToString();
                        ListPrice.Add(PriceModels);
                        Model.PriceModels = ListPrice;

                        ModelList.Add(Model);
                    }

                    ModelListMapping = MappingItemMaster(ModelList);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return ModelList.ToList();
        }

        public async Task<List<ApiItemMasterModels>> GetAllItemMasterByCatalogid(string catalogid)
        {
            List<ApiItemMasterModels> ModelList = new List<ApiItemMasterModels>();
            List<ApiItemMasterModels> ModelListMapping = new List<ApiItemMasterModels>();

            try
            {

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ItemMaster_OmniRetail_by_Catalogid";
                cmd.Parameters.Add(new SqlParameter("@Catalogid", catalogid));
                cnn.Open();
                int i = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Map data to Order class using this way
                    // orders = DataReaderMapToList<AllItemApiModels>(reader).ToList();
                    while (reader.Read())
                    {
                        ApiItemMasterModels Model = new ApiItemMasterModels();
                        Model.TypeProduct = reader["typeproduct"].ToString();
                        Model.CatalogId = reader["CatalogID"].ToString();
                        Model.Skuid = reader["SKUID"].ToString();
                        Model.SkuName = reader["SKUName"].ToString();
                        Model.StyleId = reader["StyleID"].ToString();
                        Model.StyleName = reader["StyleName"].ToString();
                        Model.ReferenceId = reader["ReferenceID"].ToString();
                        Model.ReferenceName = reader["ReferenceName"].ToString();
                        Model.Currency = reader["Currency"].ToString();
                        Model.SalesPrice = reader["SalesPrice"].ToString();
                        Model.PurchQty = reader["PurchQty"].ToString();
                        Model.BonusValue = reader["BonusValue"].ToString();
                        Model.Stock = reader["stock"].ToString();
                        Model.itemstatus = reader["ItemStatus"].ToString();
                        Model.syncDate = reader["LastSynchDateTime"].ToString();

                        SkUsApiModels SkuModels = new SkUsApiModels();
                        SkuModels.Skuid = reader["sku_skuid"].ToString();
                        SkuModels.SkuName = reader["sku_skuname"].ToString();
                        SkuModels.Catalog = reader["sku_catalog"].ToString();
                        SkuModels.Department = reader["sku_Department"].ToString();
                        SkuModels.ItemGroup = reader["sku_ItemGroup"].ToString();
                        SkuModels.Brand = reader["sku_brand"].ToString();
                        SkuModels.C1 = reader["sku_C1"].ToString();
                        SkuModels.C2 = reader["sku_C2"].ToString();
                        SkuModels.C3 = reader["sku_C3"].ToString();
                        SkuModels.Gender = reader["sku_Gender"].ToString();
                        SkuModels.Age = reader["sku_Age"].ToString();
                        SkuModels.Description = reader["sku_description"].ToString();
                        SkuModels.DescriptionEn = reader["sku_descriptionEn"].ToString();
                        SkuModels.Color = reader["sku_color"].ToString();
                        SkuModels.MarketingColor = reader["sku_marketingcolorcolor"].ToString();
                        SkuModels.Size = reader["sku_size"].ToString();
                        SkuModels.Dimension = reader["sku_dimension"].ToString();
                        SkuModels.Material = reader["sku_material"].ToString();
                        SkuModels.BodyShape = reader["sku_bodyshape"].ToString();
                        SkuModels.Fitting = reader["sku_fitting"].ToString();
                        SkuModels.StyleId = reader["sku_styleid"].ToString();
                        SkuModels.StyleName = reader["sku_stylename"].ToString();
                        SkuModels.ImagePath = reader["sku_ImagePath"].ToString();
                        SkuModels.ReferenceId = reader["sku_referenceid"].ToString();
                        SkuModels.ReferenceName = reader["sku_referencename"].ToString();
                        Model.SkuModels = SkuModels;

                        StylesApiModels StyleModels = new StylesApiModels();
                        StyleModels.StyleId = reader["style_StyleId"].ToString();
                        StyleModels.StyleName = reader["style_styleName"].ToString();
                        StyleModels.Catalog = reader["style_catalog"].ToString();
                        StyleModels.Department = reader["style_department"].ToString();
                        StyleModels.ItemGroup = reader["style_itemgroup"].ToString();
                        StyleModels.Brand = reader["style_brand"].ToString();
                        StyleModels.C1 = reader["style_c1"].ToString();
                        StyleModels.C2 = reader["style_c2"].ToString();
                        StyleModels.C3 = reader["style_c3"].ToString();
                        StyleModels.Gender = reader["style_gender"].ToString();
                        StyleModels.Description = reader["style_description"].ToString();
                        StyleModels.DescriptionEn = reader["style_descriptionEn"].ToString();
                        Model.StylesModels = StyleModels;

                        List<PriceApiModels> ListPrice = new List<PriceApiModels>();
                        PriceApiModels PriceModels = new PriceApiModels();
                        PriceModels.ItemRelation = reader["ItemRelation"].ToString();
                        PriceModels.Currency = reader["Currency"].ToString();
                        PriceModels.CatalogId = reader["CatalogID"].ToString();
                        PriceModels.AccountRelation = reader["AccountRelation"].ToString();
                        PriceModels.FromDate = reader["FromDate"].ToString();
                        PriceModels.ToDate = reader["ToDate"].ToString();
                        PriceModels.Amount = reader["Amount"].ToString();
                        ListPrice.Add(PriceModels);
                        Model.PriceModels = ListPrice;

                        ModelList.Add(Model);
                    }

                    ModelListMapping = MappingItemMaster(ModelList);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return ModelList.ToList();
        }


    }
}
