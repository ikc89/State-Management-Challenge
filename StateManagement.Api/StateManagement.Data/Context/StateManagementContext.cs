using Microsoft.EntityFrameworkCore;
using StateManagement.Data.Entities;

namespace StateManagement.Data.Context
{
    public class StateManagementContext : DbContext
    {
        public StateManagementContext(DbContextOptions<StateManagementContext> options)
            : base(options)
        {

        }

        public StateManagementContext()
        {

        }

        public DbSet<Flow> Flows { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flow>().ToTable("Flow");
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<Entities.Task>().ToTable("Task");
        }
    }
}
