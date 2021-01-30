using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndKalbeFarm.BusinessServices;
using BackEndKalbeFarm.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndKalbeFarm.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KalbeFarmaController : ControllerBase
    {
        private readonly RepositoryTestKalbeFarma _KalbeFarmaRepository;
        public KalbeFarmaController(RepositoryTestKalbeFarma Kalbe)
        {
            // _RepositoryTransporter = Transporter_PushIRepository;
            _KalbeFarmaRepository = Kalbe;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            TransactionMain data = new TransactionMain();
            try
            {
                var result = await _KalbeFarmaRepository.GetTransaction(id);

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
        public async Task<IActionResult> GetTransaction()
        {
            List<Transaction_Header> data = new List<Transaction_Header>();
            try
            {
                var result = await _KalbeFarmaRepository.GetAllTransaction();

                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertTransaction(TransactionMain Transaction)
        {
            string data ;
            try
            {
                var result = await _KalbeFarmaRepository.InsertTransaction(Transaction);

                data = result;
            }
            catch (Exception)
            {

                throw;
            }
            //return JsonConvert.SerializeObject(data);
            return Ok(new { data });
        }
    }
}
