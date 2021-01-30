using ItemMasterMagentoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.BusinessServices
{
    public interface RepositoryItemMasterOddo
    {
        Task<List<ApiItemMasterModels>> GetAllItemMaster(string CatalogId);
        Task<List<ApiItemMasterModels>> GetAllItemMasterBySkuid(string skuid);
        Task<List<ApiItemMasterModels>> GetAllItemMasterByReferenceid(string Referenceid);
        Task<List<ApiItemMasterModels>> GetAllItemMasterByCatalogid(string catalogid);
    }
}
