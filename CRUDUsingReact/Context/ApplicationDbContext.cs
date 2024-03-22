using CRUDUsingReact.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingReact.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
