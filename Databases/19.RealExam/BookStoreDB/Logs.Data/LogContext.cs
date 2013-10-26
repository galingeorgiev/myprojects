using Logs.Model;
using System.Data.Entity;

namespace Logs.Data
{
    public class LogContext : DbContext
    {
        public LogContext()
            : base("LogsContext")
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}