using _01_Forms.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_Forms.data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public DbSet<ContactFormEntity> ContactForms { get; set; }
    }
}
