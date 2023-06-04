using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options) { }
    }
}
