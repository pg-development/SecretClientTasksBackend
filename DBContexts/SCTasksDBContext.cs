using Microsoft.EntityFrameworkCore;
using SecretClientTasksBackend.Models;

namespace SecretClientTasksBackend.DBContexts
{
    public class SCTasksDBContext : DbContext
    {
        public SCTasksDBContext(DbContextOptions<SCTasksDBContext> options) : base(options)
        {
        }

        public DbSet<SCTask> SCTasks { get; set; }
    }
}
