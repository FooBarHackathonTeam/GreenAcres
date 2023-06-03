using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions options) : base(options) { }

    }
}
