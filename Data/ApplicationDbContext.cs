using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<EmployeeDetails> EmployeeDetails {  get; set; }
        public void EnableIdentityInsert(string tableName, bool enable)
        {
            // This method executes raw SQL to enable or disable IDENTITY_INSERT for the specified table
            string sql = $"SET IDENTITY_INSERT {tableName} {(enable ? "ON" : "OFF")};";
            Database.ExecuteSqlRaw(sql);
        }
    }
}
