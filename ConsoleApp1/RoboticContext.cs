using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class RoboticContext: DbContext
    {
        public DbSet<CommandLog> CommandLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=35.244.122.194;Database=robotic;Username=developer;Password=au4a83");
    }

    public enum CommandType
    {
        [Description("place robot")]
        PLACE_ROBOT,
        
        [Description("move north")]
        MOVE_NORTH,
        
        [Description("move east")]
        MOVE_EAST,
        
        [Description("move south")]
        MOVE_SOUTH,
        
        [Description("move west")]
        MOVE_WEST
        
    }

    public class CommandLog
    {
        [Key]
        public int Id { get; set; }

        public CommandType Type { get; set; }
    }
}