using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
namespace EFDataAccessLibrary.DataAccess
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options) { }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Element> Elements { get; set; }
    }
}
