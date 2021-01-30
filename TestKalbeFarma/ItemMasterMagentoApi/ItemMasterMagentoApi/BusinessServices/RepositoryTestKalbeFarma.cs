using BackEndKalbeFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndKalbeFarm.BusinessServices
{
    public interface RepositoryTestKalbeFarma
    {
        Task<List<Transaction_Header>> GetAllTransaction();
        Task<TransactionMain> GetTransaction(string Invoice);
        Task<string> InsertTransaction(TransactionMain insert);
        
    }
}
