using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMasterMagentoApi.Models
{
    public class mscontext : DbContext
    {
        public mscontext(DbContextOptions<mscontext> options)
          : base(options)
        {
        }


    }
}
