using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIHandson_1_3_.Models
{
    public class EmpDBContext : DbContext
    { 
        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
        {
        }
        public DbSet<Emp> Employees { get; set; }
    }
}
