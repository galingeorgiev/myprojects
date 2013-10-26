using Logs.Data;
using Logs.Data.Migrations;
using Logs.Model;
using System;
using System.Data.Entity;

namespace Logs.Client
{
    public static class LogsWriter
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LogContext, Configuration>());

            using (var db = new LogContext())
            {
                Log test = new Log() { LogDate = DateTime.Now, LogQuery = "alabala" };
                db.Logs.Add(test);
                db.SaveChanges();
            }
        }

        public static void Writer(string query)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LogContext, Configuration>());

            using (var db = new LogContext())
            {
                Log newLog = new Log() { LogDate = DateTime.Now, LogQuery = query };
                db.Logs.Add(newLog);
                db.SaveChanges();
            }
        }
    }
}