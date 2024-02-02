using Microsoft.EntityFrameworkCore;
using TaskManagerCommon.Entities;

namespace TaskManagerDAL
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<Status> Status { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }
    }
}
