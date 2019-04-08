using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheZeusAPI.Models
{
    public class DbModel : DbContext 
    {
        public DbModel(DbContextOptions<DbModel>options) :base(options)
        {

        }

        public DbSet<PayInfo> PayInfo { get; set; }
    }
}
