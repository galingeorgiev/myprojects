using System;
using System.ComponentModel.DataAnnotations;

namespace Logs.Model
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public string LogQuery { get; set; }
    }
}
