using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemMasterMagentoApi.BusinessServices;
using ItemMasterMagentoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEndKalbeFarm.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : ControllerBase
    {

        private readonly RepositoryItemMasterOddo _ItemMasterRepository;
        // private readonly Transporter_PushIRepository _RepositoryTransporter;
        public ItemMasterController(RepositoryItemMasterOddo jda_OrdIRepository)
        {
            // _RepositoryTransporter = Transporter_PushIRepository;
            _ItemMasterRepository = jda_OrdIRepository;
        }


        #region CONTEXT
        [HttpGet("[action]")]
        public async Task<IActionResult> GetItemMaster(string id)
        {
            List<ApiItemMasterModels> data = new List<ApiItemMasterModels>();
            try
            {
                var result = await _ItemMasterRepository.GetAllItemMaster(id);
               
                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetItemMasterByReferenceid(string id)
        {
            List<ApiItemMasterModels> data = new List<ApiItemMasterModels>();
            try
            {
                var result = await _ItemMasterRepository.GetAllItemMasterByReferenceid(id);

                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetItemMasterByskuid(string id)
        {
            List<ApiItemMasterModels> data = new List<ApiItemMasterModels>();
            try
            {
                var result = await _ItemMasterRepository.GetAllItemMasterBySkuid(id);

                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetItemMasterByCatalogid(string id)
        {
            List<ApiItemMasterModels> data = new List<ApiItemMasterModels>();
            try
            {
                var result = await _ItemMasterRepository.GetAllItemMasterByCatalogid(id);

                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }
        #endregion
    }
}