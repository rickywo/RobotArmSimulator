using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class RoboticContext: DbContext
    {
        public DbSet<CommandLog> CommandLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=35.244.122.194;Database=robotic;Username=developer;Password=au4a83");
    }
    
    public class CommandLog
    {
        public int CommandLogId { get; set; }
        public string Command { get; set; }
    }
}