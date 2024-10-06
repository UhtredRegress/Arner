using Arner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess
{
    public class ArnerDbContext:DbContext
    {
        public ArnerDbContext(DbContextOptions<ArnerDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
